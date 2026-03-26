using MediatR;
using TutoApiformation.Interface.UnitOfWork;
using TutoApiFormation.Applications.DTO.Infrastructure;
using TutoApiFormation.Domain;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllCategoriesHandler(IUnitOfWork unit) : IRequestHandler<SelectAllCategoriesQuery, IEnumerable<CategorieDTO>>
    {
        #region private properties
        private readonly IUnitOfWork _unit = unit;
        #endregion

        #region implement interface 
        /// <summary>
        /// MediatR méthode qui retourne toutes les categories de cours
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CategorieDTO>> Handle(SelectAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = _unit.Repository<Categorie>()!.GetAll().Select(item => new CategorieDTO()
            {
                Title = item.Title,
                Message = item.Message,
                Image = item.Image,
                Count = _unit.Repository<Formation>()!.Where(f => f.CategorieId == item.Id).Count().ToString() + " cours"
            }).ToList();

            return result;
        }
        #endregion
    }
}
