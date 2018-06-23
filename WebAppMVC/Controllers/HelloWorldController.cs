using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Models.PesanModel data)
        {
            ViewBag.Pesan = data.Name + " Mengatakan " + data.Message;
            return View();
        }
    }
}