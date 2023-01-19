using MaxFit.Models.Login;
using System.Web.Mvc;
using System.Web.Security;

namespace MaxFit.Controllers
{
    public class AccesController : Controller
    {
        readonly UserLoginRepository _userLoginRepository = new UserLoginRepository();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            if (_userLoginRepository.Login(userLogin))
            {

                FormsAuthentication.SetAuthCookie(userLogin.User, false);
                return RedirectToAction("Home", "MaxFit");
           }
            else
            {
                return View();
            }
        }


    }
}