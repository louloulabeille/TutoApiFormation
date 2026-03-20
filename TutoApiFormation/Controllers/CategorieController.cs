using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoApiformation.Infrastructure;
using TutoApiformation.Infrastructure.Database;
using TutoApiformation.Interface.UnitOfWork;
using TutoApiFormation.Applications.DTO.Infrastructure;
using TutoApiFormation.Applications.Queries;
using TutoApiFormation.Domain.Infrastructure;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategorieController(IMediator mediaR) : ControllerBase
    {
        #region private properties
        // - private readonly IUnitOfWork _unit = unit;
        private readonly IMediator _mediaR = mediaR;
        #endregion

        #region methode controller
        /// <summary>
        /// Retourne toutes les categories de la base de données pour les 
        /// injectées dans l'application
        /// </summary>
        /// <returns></returns>
        [Route("GetAllCategories")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            /*var categories = _unit.Repository<Categorie>()!.GetAll().Select(item=> new CategorieDTO()
            { 
                Title = item.Title,
                Message = item.Message,
                Image = item.Image,
                Count = new Random().Next(100)  // --  il faudra le programmer par la suite pour retourner les leçons dans la base
            }).ToList();

            if (categories.Count() == 0) return this.BadRequest("Problem with return categories");
            else return this.Ok(categories);
            */

            var categories = await this._mediaR.Send(new SelectAllCategoriesQuery());
            if (categories.Count() == 0 ) return this.BadRequest("Problem with return categories");
            else return this.Ok(categories);

        }

        #endregion
    }
}
