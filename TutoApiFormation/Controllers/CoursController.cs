using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoApiFormation.Applications.DTO.Infrastructure;
using TutoApiFormation.Applications.Queries;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursController(IMediator mediaR) : ControllerBase
    {
        #region private properties
        private readonly IMediator _mediaR = mediaR;
        #endregion

        [Route("GetAllCoursByIdFormation")]
        [HttpGet]
        public async Task<IActionResult> GetAllByFormationAsync([FromQuery] int? id)
        {

            // - IMediator découplage entre la demande de données et les ordres
            try
            {
                if (id is null) return this.BadRequest("Bad request id is null");

                var formationVideoDTO = await this._mediaR.Send(new SelectAllCoursByIdFormationQuery() { 
                    IdFormation = id.Value
                });

                if (formationVideoDTO.Videos!.Count == 0) return this.BadRequest("Empty or internal problem.");
                else return this.Ok(formationVideoDTO);
            }
            catch (Exception ex)
            {
                // par suite mettre en place les log
                Console.WriteLine($"{DateTime.Now}--Error Message : {ex.Message}");
            }

                return this.Ok();
        }

    }
}
