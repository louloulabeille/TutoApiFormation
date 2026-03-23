namespace TutoApiFormation.Applications.DTO.Infrastructure
{
    /// <summary>
    /// Classe infrastructure pour la transmission de la mise en forme de la page Maui
    /// MainPage pour afficher les différentes catégories de cours 
    /// </summary>
    public class CategorieDTO
    {
        //public int Id { get; set; }
        public required string Title { get; set; }
        public string? Message { get; set; }
        public string? Image { get; set; }
        public int Count { get; set; } = 0;

    }
}
