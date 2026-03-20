using MediatR;
using TutoApiformation.Interface.UnitOfWork;
using TutoApiFormation.Applications.DTO.Infrastructure;
using TutoApiFormation.Domain.Infrastructure;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllCategoriesHandler(IUnitOfWork unit) : IRequestHandler<SelectAllCategoriesQuery, IEnumerable<CategorieDTO>>
    {
        #region private properties
        private readonly IUnitOfWork _unit = unit;
        #endregion

        #region implement interface 
        public async Task<IEnumerable<CategorieDTO>> Handle(SelectAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = _unit.Repository<Categorie>()!.GetAll().Select(item => new CategorieDTO()
            {
                Title = item.Title,
                Message = item.Message,
                Image = item.Image,
                Count = new Random().Next(100)
            }).ToList();

            return result;
        }
        #endregion
    }
}
