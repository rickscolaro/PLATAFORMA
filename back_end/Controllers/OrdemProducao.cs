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
    public class OrdemProducaoController : Controller
    {
        private readonly AppDbContext _context;

        public OrdemProducaoController(AppDbContext context)
        {
            _context = context;
        }

        // OrdemProducaos
         // Poderia usar List em ves de IEnumerable
        [HttpGet]
        public ActionResult<IEnumerable<OrdemProducao>> Get()
        {

            var ordemProducao = _context.OrdemProducoes.AsNoTracking().ToList();

            if (ordemProducao == null)
            {
                return NotFound("OrdemProducaos não encontrados.");
            }

            return ordemProducao;
        }

        //OrdemProducaos/1
        [HttpGet("{id}", Name = "ObterOrdemProducao")]
        public ActionResult<OrdemProducao> Get(int id)
        {

            var ordemProducao = _context.OrdemProducoes.AsNoTracking().FirstOrDefault(p => p.OrdemProducaoId == id);

            if (ordemProducao == null)
            {
                return NotFound($"OrdemProducao id={id} não encontrado");
            }
            return ordemProducao;
        }

        //OrdemProducaos
        [HttpPost]
        public ActionResult Post(OrdemProducao ordemProducao)
        {

            if (ordemProducao is null)
            {
                return BadRequest();
            }

            _context.OrdemProducoes.Add(ordemProducao);
            _context.SaveChanges();

            // Resposta padrão
            // Aciona a rota "ObterOrdemProducao"
            return new CreatedAtRouteResult("ObterOrdemProducao",
                new { id = ordemProducao.OrdemProducaoId }, ordemProducao);
        }


        // OrdemProducaos/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, OrdemProducao ordemProducao)
        {


            if (id != ordemProducao.OrdemProducaoId)
            {
                return BadRequest();
            }

            // Precisa informar a _context que o ordemProducao esta em um estado modificado
            _context.Entry(ordemProducao).State = EntityState.Modified; // Alterar o estado da entidade pa modified
            _context.SaveChanges();
            return Ok(ordemProducao);

        }


        // OrdemProducaos/1
        [HttpDelete("{id}")]
        public ActionResult<OrdemProducao> Delete(int id)
        {


            var ordemProducao = _context.OrdemProducoes.FirstOrDefault(p => p.OrdemProducaoId == id);

            if (ordemProducao == null)
            {
                return NotFound("OrdemProducao não existe");
            }

            _context.OrdemProducoes.Remove(ordemProducao);
            _context.SaveChanges();
            return Ok(ordemProducao);
        }
    }
       
}
