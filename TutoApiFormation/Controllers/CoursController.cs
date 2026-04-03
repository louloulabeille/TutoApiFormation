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


        public async Task<IActionResult> GetByFormationAsync([FromQuery] int id)
        {

            // - IMediator découplage entre la demande de données et les ordres
            try
            {
                var categories = await this._mediaR.Send(new SelectAllCategoriesQuery());
                if (!categories.Any()) return this.BadRequest("Empty or internal problem.");
                else return this.Ok(categories);
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
