using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AmaryllisTestProject.Models;
using AmaryllisTestProject.DAL.Interface;

namespace AmaryllisTestProject.Controllers
{
    public class HomeController : Controller
    {
        ICarRepository _carRepository;

            public HomeController(ICarRepository carRepository)
        {
           _carRepository = carRepository;
        }
        public IActionResult Index()
        {
            _carRepository.GetAllAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
