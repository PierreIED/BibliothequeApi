using Azure.Identity;
using BibliothequeApi.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliothequeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private UserContext DbContext
        {
            get;
        }

        private IAuthenticationService AuthenticationService
        {
            get;
        }

        public AdminsController(
            UserContext dbContext,
            IAuthenticationService authenticationService)
        {
            DbContext = dbContext;
            AuthenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login(Admin admin)
        {

            Admin? existingAdmin = DbContext.Admins.FirstOrDefault(
                u => u.UserName == admin.UserName &&
                u.MotDePasse == admin.MotDePasse);

            if (existingAdmin == null)
                return new UnauthorizedResult();

            string accessToken = AuthenticationService.GenerateToken(existingAdmin);
            return new ObjectResult(new
            {
                existingAdmin.Id,
                existingAdmin.UserName,
                access_token = accessToken
            });
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get(int id)
        {
            Admin? admin = DbContext.Admins.FirstOrDefault(u => u.Id == id);
            if (admin == null)
                return new UnauthorizedResult();

            return new ObjectResult(new
            {
                admin.Id,
                admin.UserName,
                admin.Nom,
                admin.Prenom,

            });
        }

        [HttpPost]
        public IActionResult Post(Admin admin)
        {
            // Valider l’unicité du nom d’utilisateur soumis
            if (DbContext.Admins.Count() != 0 && DbContext.Admins.FirstOrDefault(u => u.UserName == admin.UserName) != null)
                return BadRequest(new { error = "Username already in use" });
            // Auto incrémenter Id
            admin.Id = (DbContext.Admins.Count() == 0) ? 1 : DbContext.Admins.Last().Id + 1;
            DbContext.Admins.Add(admin);
            DbContext.SaveChanges();

            string accessToken = AuthenticationService.GenerateToken(admin);
            return new ObjectResult(new
            {
                admin.Id,
                admin.UserName,
                access_token = accessToken
            });
        }
    }
}
