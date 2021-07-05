using Microsoft.AspNetCore.Mvc;
using Stech.Cobrancas.Dominio.Interfaces;
using Stech.Cobrancas.WebApi.DTO;
using System;
using System.Linq;

namespace Stech.Cobrancas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CobrancaController : Controller
    {
        private readonly ICobrancaService _cobrancaService;

        public CobrancaController(ICobrancaService cobrancaService)
        {
            _cobrancaService = cobrancaService;
        }

        [HttpGet]
        public IActionResult RetornarCobrancas()
        {
            return Ok();
        }

        [HttpGet("{cpf}/{mesDeVencimento}")]
        public IActionResult RetornarCobrancas(string cpf, string mesDeVencimento)
        {
            try
            {
                var cobranca = _cobrancaService.Retornar(cpf, mesDeVencimento);
                var resultado = cobranca.Select(x => new CobrancaDTO(x.CPF.ToString(), x.DataDeVencimento, x.Valor));
                return Json(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrarcobranca(string cpf, DateTime dataDeVencimento, double valor)
        {
            try
            {
                _cobrancaService.Incluir(cpf, dataDeVencimento, valor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

