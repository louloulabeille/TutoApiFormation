using MediatR;
using TutoApiformation.Interface.UnitOfWork;
using TutoApiFormation.Applications.DTO;
using TutoApiFormation.Domain;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllFormationsByIdCategorieHandler(IUnitOfWork unitOfWork) : IRequestHandler<SelectAllFormationsByIdCategorieQuery, IEnumerable<FormationDTO>>
    {
        #region properties private readonly 
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        #region method Interface IRequestHandler
        /// <summary>
        /// Method return all Formation by CategorieId or All by CategorieId is null
        /// </summary>
        /// <param name="request"> param research </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<FormationDTO>> Handle(SelectAllFormationsByIdCategorieQuery request, CancellationToken cancellationToken)
        {
            var dbSet = _unitOfWork.Repository<Formation>();
            if (dbSet is null) return [];
 
            var result = request.CategorieId is not null ? [..dbSet.Where(f => f.CategorieId == request.CategorieId )
                .Select(f => new FormationDTO() 
                { 
                    Name = f.Name,
                    Description = f.Description,
                    Price = f.Price,
                    Tag = f.Tag,
                    ImageUrl = f.ImageUrl,
                })] :
                dbSet.GetAll().Select(f => new FormationDTO() 
                {
                    Name = f.Name,
                    Description = f.Description,
                    Price = f.Price,
                    Tag = f.Tag,
                    ImageUrl = f.ImageUrl,
                }).ToList();

            return result;
        }
        #endregion
    }
}
