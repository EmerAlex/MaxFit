using MaxFit.Models.Dto;
using MaxFit.Models.Service;
using System.Linq;
using System.Web.Mvc;

namespace MaxFit.Controllers
{
    public class MaxFitController : Controller
    {

        readonly UserService _userService = new UserService();

    
        [HttpGet]
        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Record()
        {
            return View();
        }




    }
}