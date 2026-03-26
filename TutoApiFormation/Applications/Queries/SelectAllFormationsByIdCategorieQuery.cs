using MediatR;
using TutoApiFormation.Applications.DTO;
using TutoApiFormation.Applications.DTO.Infrastructure;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllFormationsByIdCategorieQuery : IRequest<IEnumerable<FormationDTO>>
    {
        #region properties public
        // -- paramètre de recherche si null alors retourne toutes les formations
        public int? CategorieId { get; set; }
        #endregion
    }
}
