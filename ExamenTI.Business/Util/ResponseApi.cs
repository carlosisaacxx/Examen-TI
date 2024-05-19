﻿using System.Net;

namespace ExamenTI.Business.Util
{
    public class ResponseApi
    {
        public ResponseApi()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

    }
}
