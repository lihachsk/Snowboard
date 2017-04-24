using Snowboard.Domain.Abstract;
using Snowboard.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Snowboard.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        IRoot root;
        public AccountController(IRoot _root)
        {
            root = _root;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if(Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Request");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        private bool ValidateUser(string login, string password)
        {
            return root
                .User
                .CheckPassword(login, password);

        }
    }
}