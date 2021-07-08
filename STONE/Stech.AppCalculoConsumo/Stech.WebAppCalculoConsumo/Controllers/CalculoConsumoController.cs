using Microsoft.AspNetCore.Mvc;
using Stech.AppCalculoConsumo.Dominio.Interface;
using System;

namespace Stech.WebAppCalculoConsumo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoConsumoController : Controller
    {
        private readonly ICalculoConsumoService _calculoConsumoService;

        public CalculoConsumoController(ICalculoConsumoService calculoConsumoService)
        {            
            _calculoConsumoService = calculoConsumoService;
        }


        [HttpGet("{dataDeCobranca}")]
        public IActionResult CalcularConsumo(string dataDecobranca)
        {
            try
            {
                var cobrancas = _calculoConsumoService.CalcularConsumo(dataDecobranca);                
                return Json(cobrancas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
