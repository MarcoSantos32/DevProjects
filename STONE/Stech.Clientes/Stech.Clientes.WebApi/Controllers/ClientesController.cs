using Microsoft.AspNetCore.Mvc;
using Stech.Clientes.Domain.Interfaces;
using Stech.Clientes.WebApi.DTO;
using System;
using System.Linq;

namespace Stech.Clientes.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("RetornarTodos")]
        public IActionResult RetornarClientes()
        {
            try
            {
                var clientes = _clienteService.RetornarTodos();
                var resultado = clientes.Select(cliente => new ClienteDTO() { CPF = cliente.CPF.ToString(), Nome = cliente.Nome, Estado = cliente.Estado });
                return Json(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{cpf}")]        
        public IActionResult RetornarCliente(string cpf)
        {
            try
            {
                var cliente = _clienteService.Retornar(cpf);
                var resultado = new ClienteDTO() { CPF = cliente.CPF.ToString(), Nome = cliente.Nome, Estado = cliente.Estado };
                return Json(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("Cadastrar")]
        public IActionResult CadastrarCliente(string cpf, string nome, string estado)
        {
            try
            {
                _clienteService.Incluir(cpf, nome, estado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
    }
}
