﻿using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords
{
    public class HealthRecordsCommand :IRequest<HealthRecordsResponse>
    {
        public HealthRecordsDTO HealthRecords { get; set; }

        public HealthRecordsCommand (HealthRecordsDTO healthRecords)
        {
            HealthRecords = healthRecords;
        }
    }
}
