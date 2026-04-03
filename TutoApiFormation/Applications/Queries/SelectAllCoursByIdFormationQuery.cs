using MediatR;
using TutoApiFormation.Applications.DTO.Infrastructure;

namespace TutoApiFormation.Applications.Queries
{
    public class SelectAllCoursByIdFormationQuery : IRequest<FormationVideosDTO>
    {
        public int IdFormation { get; set; }
    }
}
