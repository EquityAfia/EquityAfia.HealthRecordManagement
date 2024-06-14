﻿using Microsoft.AspNetCore.Http;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs
{
    public class LabResultsDTO
    {
        public string? Diagnosis { get; set; }
        public string? Test { get; set; }
        public string? Results { get; set; }
        public string? Prescriptions { get; set; }
        public IFormFile TestImage { get; set; }
        public IFormFile ResultsImage { get; set; }
    }
}
