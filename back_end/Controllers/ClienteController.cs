using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Context;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // Clientes
         // Poderia usar List em ves de IEnumerable
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {

            var cliente = _context.Clientes.AsNoTracking().ToList();

            if (cliente == null)
            {
                return NotFound("Clientes não encontrados.");
            }

            return cliente;
        }

        //Clientes/1
        [HttpGet("{id}", Name = "ObterCliente")]
        public ActionResult<Cliente> Get(int id)
        {

            var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(p => p.ClienteId == id);

            if (cliente == null)
            {
                return NotFound($"Cliente id={id} não encontrado");
            }
            return cliente;
        }

        //Clientes
        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {

            if (cliente is null)
            {
                return BadRequest();
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            // Resposta padrão
            // Aciona a rota "ObterCliente"
            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.ClienteId }, cliente);
        }


        // Clientes/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Cliente cliente)
        {


            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            // Precisa informar a _context que o cliente esta em um estado modificado
            _context.Entry(cliente).State = EntityState.Modified; // Alterar o estado da entidade pa modified
            _context.SaveChanges();
            return Ok(cliente);

        }


        // Clientes/1
        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id)
        {


            var cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);

            if (cliente == null)
            {
                return NotFound("Cliente não existe");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
    }
}