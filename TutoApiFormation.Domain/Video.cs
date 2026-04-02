using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiFormation.Domain
{
    public class Video
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? UrlVideo { get; set; }
        public string? Description { get; set; }
        public string? Time { get; set; }
        public int FormationId { get; set; }
        public Formation? Formation { get; set; }
    }
}
