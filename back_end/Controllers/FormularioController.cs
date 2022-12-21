

using back_end.Context;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularioController : Controller
    {
        private readonly AppDbContext _context;

        public FormularioController(AppDbContext context)
        {
            _context = context;
        }

        // Formularios
        [HttpGet]
        // Poderia usar List em ves de IEnumerable
        public ActionResult<IEnumerable<Formulario>> Get()
        {

            var formulario = _context.Formularios.AsNoTracking().ToList();

            if (formulario == null)
            {
                return NotFound("Formularios não encontrados.");
            }

            return formulario;
        }

        //Formularios/1
        [HttpGet("{id}", Name = "ObterFormulario")]
        public ActionResult<Formulario> Get(int id)
        {

            var formulario = _context.Formularios.AsNoTracking().FirstOrDefault(p => p.FormularioId == id);

            if (formulario == null)
            {
                return NotFound($"Formulario id={id} não encontrado");
            }
            return formulario;
        }

        //Formularios
        [HttpPost]
        public ActionResult Post(Formulario formulario)
        {

            if (formulario is null)
            {
                return BadRequest();
            }

            _context.Formularios.Add(formulario);
            _context.SaveChanges();

            // Resposta padrão
            // Aciona a rota "ObterFormulario"
            return new CreatedAtRouteResult("ObterFormulario",
                new { id = formulario.FormularioId }, formulario);
        }


        // Formularios/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Formulario formulario)
        {


            if (id != formulario.FormularioId)
            {
                return BadRequest();
            }

            // Precisa informar a _context que o formulario esta em um estado modificado
            _context.Entry(formulario).State = EntityState.Modified; // Alterar o estado da entidade pa modified
            _context.SaveChanges();
            return Ok(formulario);

        }


        // Formularios/1
        [HttpDelete("{id}")]
        public ActionResult<Formulario> Delete(int id)
        {


            var formulario = _context.Formularios.FirstOrDefault(p => p.FormularioId == id);

            if (formulario == null)
            {
                return NotFound("Formulario não existe");
            }

            _context.Formularios.Remove(formulario);
            _context.SaveChanges();
            return Ok(formulario);
        }
    }
}
