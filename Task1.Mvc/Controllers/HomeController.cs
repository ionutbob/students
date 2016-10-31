using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Core.Interfaces;
using Task1.Core.Services;
using Task1.Infrastructure.Data;
using Task1.Mvc.Models;


namespace Task1.Mvc.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index(int page = 1)
        {
            return RedirectToAction("Index", "Students");            
        }        
    }
}