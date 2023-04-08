using MaxFit.Models.Dto;
using MaxFit.Models.Service;
using System.Linq;
using System.Web.Mvc;

namespace MaxFit.Controllers
{
    public class MaxFitController : Controller
    {

       
    
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

        [HttpGet]
        [Authorize]
        public ActionResult Drink()
        {
            return View();
        }




    }
}