using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AppMascotaMvc.Models;
using Microsoft.AspNetCore.Authorization;
namespace AppMascotaMvc.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // return View();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
