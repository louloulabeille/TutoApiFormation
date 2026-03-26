using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiFormation.Applications.DTO.Infrastructure
{
    public class IdentityDTO
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
