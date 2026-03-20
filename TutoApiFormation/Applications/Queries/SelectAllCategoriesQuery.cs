using MediatR;
using TutoApiFormation.Applications.DTO.Infrastructure;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllCategoriesQuery : IRequest<IEnumerable<CategorieDTO>>
    {
        // pas de données pour la recherche - return allCategories
    }
}
