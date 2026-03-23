using System.Text.Json.Serialization;

namespace TutoApiFormation.Applications.DTO.Infrastructure
{
    /// <summary>
    /// Classe infrastructure pour la transmission de la mise en forme de la page Maui
    /// MainPage pour afficher les différentes catégories de cours 
    /// </summary>
    public class CategorieDTO
    {
        //public int Id { get; set; }
        //[JsonPropertyName("Title")]
        public required string Title { get; set; }
        //[JsonPropertyName("Message")]
        public string? Message { get; set; }
        //[JsonPropertyName("Image")]
        public string? Image { get; set; }
        //[JsonPropertyName("Count")]
        public int Count { get; set; } = 0;

    }
}
