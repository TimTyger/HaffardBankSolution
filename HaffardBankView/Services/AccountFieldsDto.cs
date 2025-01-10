﻿namespace HaffardBankWebApp.Services
{
    public class AccountFieldsDto
    {
        public string? AccountNumber { get; set; }
        public string? Industry { get; set; }
        public List<FieldsDto> Fields { get; set; } = [];
    }

    public class FieldsDto
    {
        public string? FieldName { get; set; }
        public string? FieldType { get; set; }
        public string? FieldValue { get; set; }

    }
}