using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiFormation.Applications.DTO.Infrastructure
{
    public class FormationVideosDTO
    {
        public List<VideoDTO>? Videos { get; set; }
        public RessourceDTO? Ressource { get; set; }
    }

}
