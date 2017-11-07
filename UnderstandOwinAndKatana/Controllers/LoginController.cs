using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using UnderstandOwinAndKatana.Models;

namespace UnderstandOwinAndKatana.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Auth()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Auth(LoginModel model)
        {
            if (model.UserName == model.Password)
            {
                var identity = new ClaimsIdentity("ApplicationCookie");
                identity.AddClaims(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,model.UserName),
                    new Claim(ClaimTypes.Name, model.UserName)
                });
                HttpContext.GetOwinContext().Authentication.SignIn(identity);
            }
                
            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}