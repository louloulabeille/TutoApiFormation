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

        // - cardinalite 0,n
        public List<Video>? Videos { get; set; }


        // - cardinalite 0,1
        public int? RessourcesId { get; set; }
        public Ressource? Ressource { get; set; }
    }
}
