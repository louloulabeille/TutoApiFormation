using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TutoApiFormation.Applications.DTO.Infrastructure;

namespace TutoApiFormation.Applications.DTO.Http 
{ 
    public class ResultHttp
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? HttpContentMessage { get; set; }
        public IdentityDTO? IdentityDTO { get; set; }
    }
}
