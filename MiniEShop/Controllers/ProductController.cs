using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniEShop.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        // GET: Product
        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}