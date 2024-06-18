﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs
{
    public class DownloadLabResultsResponse
    {
        public Guid LabResultsId { get; set; }
        public IFormFile PdfFile { get; set; }
    }
}
