using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TutoApiformation.Infrastructure.Configuration;
using TutoApiFormation.Applications.DTO.Infrastructure;
using TutoApiFormation.Applications.Security;

namespace TutoApiFormation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController(SignInManager<IdentityUser> signInManager, IOptions<SecurityJwtBearer> options ) : ControllerBase
    {
        #region Properties private readonly
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly SecurityJwtBearer _options = options.Value;
        #endregion


        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] IdentityDTO  identity)
        {
            if (identity is null || identity.Password is null) return this.BadRequest("Login ou mot de passe manquand");

            var user = new IdentityUser(identity.Email!)
            {
                Email = identity.Email,
                UserName = identity.Name ?? identity.Email,
            };

            var success = await _signInManager.UserManager.CreateAsync(user, identity.Password);

            if (success.Succeeded)
            {
                identity.Tokken = SecurityTokenGenerate.GenerateJwtToken(user, _options);
                identity.Password = "";
            }
            else
                return BadRequest(success.Errors);

            return this.Ok(identity);
        }


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] IdentityDTO identity)
        {
            if (identity is null || string.IsNullOrEmpty(identity.Password) || string.IsNullOrEmpty(identity.Email))
                return this.BadRequest("Login ou mot de passe manquant");

            try
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(identity.Email);
                if (user is null) return BadRequest("Login ou mot de passe incorrecte");
                var result = await _signInManager.CheckPasswordSignInAsync(user, identity.Password!, true);
                if (result.Succeeded)
                {
                    identity.Tokken = SecurityTokenGenerate.GenerateJwtToken(user, _options);
                    identity.Password = string.Empty;
                    return this.Ok(identity);
                }

                return BadRequest("Login ou mot de passe incorrecte");
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"{DateTime.Now}--Error Message : {ex.Message}");
#endif
                return this.Problem("internal Problem.");
            }
        }

    }
}
