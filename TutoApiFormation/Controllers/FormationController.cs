using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoApiFormation.Applications.Queries;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormationController(IMediator mediatR) : ControllerBase
    {

        #region Properties Private readonly 
        private readonly IMediator _mediatR = mediatR;
        #endregion


        #region public Action
        [Route("FormationByCategorieId")]
        [HttpGet]
        public async Task<IActionResult> GetAllByIdCategorie([FromQuery] int? id)
        {
            try
            {
                var result = await _mediatR.Send(new SelectAllFormationsByIdCategorieQuery() { CategorieId = id });
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}--Error Message : {ex.Message}");

                return this.Problem("internal problem");
            }
            
        } 
        #endregion

    }
}
