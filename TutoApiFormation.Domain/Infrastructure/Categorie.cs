using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiFormation.Domain.Infrastructure
{
    /// <summary>
    /// Classe d'infrastructure pour enregistrer les différentes categories de l'application
    /// qui seront affichées
    /// </summary>
    public class Categorie
    {
        public int Id { get; set; }
        public required string Title {  get; set; }
        public string? Message { get; set; }
        public string? Image { get; set; }
    }
}
