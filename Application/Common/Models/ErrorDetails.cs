﻿using System.Text.Json;

namespace Application.Common.Models
{
    public sealed class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }= string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
