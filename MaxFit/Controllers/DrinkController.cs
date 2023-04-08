using MaxFit.Models.Dto.Drink;
using MaxFit.Models.Service.Drink;
using System;
using System.Web.Mvc;

namespace MaxFit.Controllers
{
    public class DrinkController : Controller
    {
        readonly DrinkService _drinkService = new DrinkService();

        [HttpGet]
        [Authorize]
        public JsonResult FindAllDrinks() {

            return Json(new { data = _drinkService.AllDrinks() }, JsonRequestBehavior.AllowGet);
        
        }

        [HttpPost]
        [Authorize]
        public JsonResult FindFilterDrinks(DrinkSearchDTO drinkSubmit )
        {
            
            return Json(new { result = _drinkService.FindFilterDrinks(drinkSubmit.InitialDate, drinkSubmit.FinlaDate) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public JsonResult SaveDrink()
        {
            return Json(new { result = _drinkService.SaveDrink() }, JsonRequestBehavior.AllowGet);
        }

    }
}