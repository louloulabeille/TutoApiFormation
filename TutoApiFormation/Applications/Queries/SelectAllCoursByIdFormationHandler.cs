using MediatR;
using TutoApiformation.Interface.UnitOfWork;
using TutoApiFormation.Applications.DTO.Infrastructure;
using TutoApiFormation.Domain;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllCoursByIdFormationHandler(IUnitOfWork unitOfWork) : IRequestHandler<SelectAllCoursByIdFormationQuery, FormationVideosDTO>
    {
        #region private readonly properties
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        public async Task<FormationVideosDTO> Handle(SelectAllCoursByIdFormationQuery request, CancellationToken cancellationToken)
        {
            var videoDbset = _unitOfWork.Repository<Video>();
            var ressourceDbset = _unitOfWork.Repository<Ressource>();

            var result = new FormationVideosDTO()
            {
                Videos = videoDbset is not null ? videoDbset.Where(v => v.FormationId == request.IdFormation).Select(v => new VideoDTO
                {
                    Title = v.Title,
                    Description = v.Description,
                    UrlVideo = v.UrlVideo,
                    Time = v.Time
                }).ToList() : [],

                Ressource = ressourceDbset is not null ? ressourceDbset.Where(r => r.FormationId == request.IdFormation)
                .Select(r => new RessourceDTO()
                {
                    Lien = r.Lien
                }).FirstOrDefault() : null
            };

            return result;

        }
    }
}
