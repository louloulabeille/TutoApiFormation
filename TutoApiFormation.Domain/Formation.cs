using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiFormation.Domain
{
    public class Formation
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Tag { get; set; }

        // - cardinalite 1,1
        public int CategorieId { get; set; }
        public Categorie? Categorie {  get; set; }
    }
}
