


using back_end.Context;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // Produtos
        [HttpGet]
        // Poderia usar List em ves de IEnumerable
        public ActionResult<IEnumerable<Produto>> Get()
        {

            var produto = _context.Produtos.AsNoTracking().ToList();

            if (produto == null)
            {
                return NotFound("Produtos não encontrados.");
            }

            return produto;
        }

        //Produtos/1
        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {

            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound($"Produto id={id} não encontrado");
            }
            return produto;
        }

        //Produtos
        [HttpPost]
        public ActionResult Post(Produto produto)
        {

            if (produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            // Resposta padrão
            // Aciona a rota "ObterProduto"
            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }


        // Produtos/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Produto produto)
        {


            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            // Precisa informar a _context que o produto esta em um estado modificado
            _context.Entry(produto).State = EntityState.Modified; // Alterar o estado da entidade pa modified
            _context.SaveChanges();
            return Ok(produto);

        }


        // Produtos/1
        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {


            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Produto não existe");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }
    }
}