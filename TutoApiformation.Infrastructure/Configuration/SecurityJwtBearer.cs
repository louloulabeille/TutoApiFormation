using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiformation.Infrastructure.Configuration
{
    public class SecurityJwtBearer
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
    }
}
