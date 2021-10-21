﻿using System.Collections.Generic;

namespace Common.Services.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }
        public BaseResponse(string message, bool sucess)
        {
            Success = sucess;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
