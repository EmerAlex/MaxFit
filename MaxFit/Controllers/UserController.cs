using MaxFit.Models.Dto;
using MaxFit.Models.Service;
using System.Linq;
using System.Web.Mvc;

namespace MaxFit.Controllers
{
    public class UserController : Controller
    {

        readonly UserService _userService = new UserService();
        public ActionResult FindUser()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FindUser(UserSearchDTO userDto)
        {
            if (!(userDto.Identity == null || userDto.Identity.Trim() == ""))
            {
                userDto.UserQuery = _userService.FindUser(userDto.Identity);
                
            }
            return View(userDto);
        }

        [Authorize]
        public ActionResult SaveUser()
        {
            return View();
        }
 
        [HttpPost]
        [Authorize]
        public JsonResult SaveUser(UserSubmitDTO userSubmit)
        {
            return Json(new { result = _userService.AddUser(userSubmit)},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public JsonResult UpdateUser(UserSubmitDTO userSubmit)
        {    
            return Json(new { result = _userService.UpdateUser(userSubmit) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public JsonResult FindAllUsers()
        {

            return Json(new { data = _userService.FindAll().ToList() }, JsonRequestBehavior.AllowGet);
        }

    }
}