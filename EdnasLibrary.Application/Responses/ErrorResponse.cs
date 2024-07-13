﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdnasLibrary.Application.Responses
{
    public class ErrorResponse(int statusCode, string errorMessage, string details) : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }

    }
}
