﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand
{
    public class LabResultsUploadCommandHandler : IRequestHandler<LabResultsUploadCommand, LabResultsResponse>
    {
        private readonly ILabResultsRepository _labResultsRepository;

        public LabResultsUploadCommandHandler(ILabResultsRepository labResultsRepository)
        {
            _labResultsRepository = labResultsRepository;
        }

        public async Task<LabResultsResponse> Handle(LabResultsUploadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var labResult = request.LabResults;
                var labResultId = Guid.NewGuid();

                byte[] testimage = await ProcessFile(labResult.TestImage!);

                byte[] resultimage = await ProcessFile(labResult.ResultsImage!);


                var labResults = new LabResults
                {
                    LabResultsId = labResultId,
                    IdNumber = labResult.IdNumber!,
                    Diagnosis = labResult.Diagnosis!,
                    Test = labResult.Test!,
                    Results = labResult.Results!,
                    Prescriptions = labResult.Prescriptions!,
                    TestImage = testimage,
                    ResultsImage = resultimage
                };

                await _labResultsRepository.AddAsync(labResults);

                var response = new LabResultsResponse
                {
                    LabResultsId = labResultId,
                };

                return response;


            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during processing your request",ex);
            }
        }

        private async Task<byte[]> ProcessFile(IFormFile file)
        {
            try
            {
                byte[] testimage;

                using (var memorystream = new MemoryStream())
                {
                    await file.CopyToAsync(memorystream);

                    testimage = memorystream.ToArray();
                }
                return testimage;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to convert to byte",ex);
            }
        }
    }
}
