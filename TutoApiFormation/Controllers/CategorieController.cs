using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoApiformation.Infrastructure.Database;
using TutoApiFormation.Applications.DTO.Infrastructure;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategorieController(TutoApiDbContext context) : ControllerBase
    {
        #region private properties
        private readonly TutoApiDbContext _context = context;
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

            var categories = _context.Categories.Select(item=> new CategorieDTO()
            { 
                Title = item.Title,
                Message = item.Message,
                Image = item.Image,
                Count = new Random().Next(100)  // --  il faudra le programmer par la suite pour retourner les leçons dans la base
            });

            if (categories.Count() == 0) return this.BadRequest("Problem with return categories");
            else return this.Ok(categories);

        }

        #endregion
    }
}
