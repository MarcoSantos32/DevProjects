using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stech.AppCalculoDeConsumo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoConsumoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
