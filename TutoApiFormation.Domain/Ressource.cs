using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiFormation.Domain
{
    public class Ressource
    {
        public int Id { get; set; }
        public required string Lien { get; set; }
        public int FormationId { get; set; }
        public Formation? Formation { get; set; }
    }
}
