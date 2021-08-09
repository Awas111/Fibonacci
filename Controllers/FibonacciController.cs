using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fibonacci.Models;

namespace Fibonacci.Controllers
{
    public class FibonacciController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(FibonacciModel model)
        {
            if (model.limit < 2 || model.limit >= 4000000)// first check limit
            {
                ViewBag.ErrorMessage = "Enter valid limit between 2 - 4000000";
            }
            else
            {
                long firstEN = 0;
                long secondEN = 2;
                long Sum = firstEN + secondEN;
                while (secondEN < model.limit)
                {
                    long thirdEN = 4 * secondEN + firstEN;
                    if (thirdEN > model.limit)
                        break;
                    firstEN = secondEN;
                    secondEN = thirdEN;
                    Sum += secondEN;
                }
                model.Sum = Sum;
            }
                return View(model);
            
        }
    }
}
