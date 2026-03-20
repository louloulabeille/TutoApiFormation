using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoApiformation.Infrastructure.Database;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Categorie(TutoApiDbContext context) : ControllerBase
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

            return this.BadRequest();
        }

        #endregion
    }
}
