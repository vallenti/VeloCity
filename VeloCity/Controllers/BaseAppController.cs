using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeloCity.Data;
using VeloCity.Models;

namespace VeloCity.Controllers
{
    [ApiController]
    public class BaseAppController : ControllerBase
    {
        protected ApplicationDbContext _context;

        protected UserManager<ApplicationUser> _userManager;

        public BaseAppController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        protected string CurrentUserId => this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
