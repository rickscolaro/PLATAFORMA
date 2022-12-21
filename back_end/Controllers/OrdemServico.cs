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
    public class OrdemServicoController : Controller
    {
        private readonly AppDbContext _context;

        public OrdemServicoController(AppDbContext context)
        {
            _context = context;
        }

        // OrdemServicos
         // Poderia usar List em ves de IEnumerable
        [HttpGet]
        public ActionResult<IEnumerable<OrdemServico>> Get()
        {

            var ordemServico = _context.OrdemServicos.AsNoTracking().ToList();

            if (ordemServico == null)
            {
                return NotFound("OrdemServicos não encontrados.");
            }

            return ordemServico;
        }

        //OrdemServicos/1
        [HttpGet("{id}", Name = "ObterOrdemServico")]
        public ActionResult<OrdemServico> Get(int id)
        {

            var ordemServico = _context.OrdemServicos.AsNoTracking().FirstOrDefault(p => p.OrdemServicoId == id);

            if (ordemServico == null)
            {
                return NotFound($"OrdemServico id={id} não encontrado");
            }
            return ordemServico;
        }

        //OrdemServicos
        [HttpPost]
        public ActionResult Post(OrdemServico ordemServico)
        {

            if (ordemServico is null)
            {
                return BadRequest();
            }

            _context.OrdemServicos.Add(ordemServico);
            _context.SaveChanges();

            // Resposta padrão
            // Aciona a rota "ObterOrdemServico"
            return new CreatedAtRouteResult("ObterOrdemServico",
                new { id = ordemServico.OrdemServicoId }, ordemServico);
        }


        // OrdemServicos/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, OrdemServico ordemServico)
        {


            if (id != ordemServico.OrdemServicoId)
            {
                return BadRequest();
            }

            // Precisa informar a _context que o ordemServico esta em um estado modificado
            _context.Entry(ordemServico).State = EntityState.Modified; // Alterar o estado da entidade pa modified
            _context.SaveChanges();
            return Ok(ordemServico);

        }


        // OrdemServicos/1
        [HttpDelete("{id}")]
        public ActionResult<OrdemServico> Delete(int id)
        {


            var ordemServico = _context.OrdemServicos.FirstOrDefault(p => p.OrdemServicoId == id);

            if (ordemServico == null)
            {
                return NotFound("OrdemServico não existe");
            }

            _context.OrdemServicos.Remove(ordemServico);
            _context.SaveChanges();
            return Ok(ordemServico);
        }
    }
}