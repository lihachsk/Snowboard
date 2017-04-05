using Snowboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snowboard.WebUI.Controllers
{
    public class MainController : Controller
    {
        private IRoot root;
        public MainController(IRoot _root)
        {
            root = _root;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}