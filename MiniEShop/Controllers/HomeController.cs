﻿using System.Web.Mvc;
using BL;
using DomainClasses.Models;

namespace MiniEShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var pBL = new ProductBL();
            var s = pBL.Save(new Product {ProductName = "Test"});

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}