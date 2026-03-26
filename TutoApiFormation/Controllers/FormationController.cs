using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormationController (IMediator mediator) : ControllerBase
    {

        #region Properties Private readonly 
        private readonly IMediator _mediator = mediator;
        #endregion


        #region public Action

        #endregion

    }
}
