
using back_end.Models;
using back_end.Models.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_end.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<OrdemProducao> OrdemProducoes { get; set; }
        public DbSet<OrdemServico> OrdemServicos { get; set; }




        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<OrdemServico>().HasOne(e => e.Produto).WithMany(e => e.OrdemServicos).HasForeignKey(e => new { e.ProdutoId }).OnDelete(DeleteBehavior.Restrict);
            // mb.Entity<OrdemServico>().HasOne(e => e.Produto).WithMany().OnDelete(DeleteBehavior.Restrict);
            //mb.Entity<Produto>().HasMany(e => e.OrdemServicos);

            mb.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteId = 1,
                    Descricao = "Apple",
                },
                 new Cliente
                 {
                     ClienteId = 2,
                     Descricao = "Microsoft",
                 }
            );
            mb.Entity<OrdemProducao>().HasData(
              new OrdemProducao
              {
                  OrdemProducaoId = 1,
                  Descricao = "Producao Apple",
                  ClienteId = 1,
                  ProdutoId = 1,
                  Situacao = EnumOrdemProducaoSituacao.EM_PLANEJAMENTO
              },
              new OrdemProducao
              {
                  OrdemProducaoId = 2,
                  Descricao = "Producao Microsof",
                  ClienteId = 2,
                  ProdutoId = 3,
                  Situacao = EnumOrdemProducaoSituacao.EM_PLANEJAMENTO
              }
            );
            mb.Entity<OrdemServico>().HasData(
              new OrdemServico
              {
                  OrdemServicoId = 1,
                  Descricao = "Servico Apple",
                  ProdutoId = 1,
                  OrdemProducaoId = 1,
                  Situacao = EnumOrdemServicoSituacao.EM_PLANEJAMENTO
              },
              new OrdemServico
              {
                  OrdemServicoId = 2,
                  Descricao = "Servico Apple",
                  ProdutoId = 2,
                  OrdemProducaoId = 1,
                  Situacao = EnumOrdemServicoSituacao.EM_PLANEJAMENTO
              },
              new OrdemServico
              {
                  OrdemServicoId = 3,
                  Descricao = "Servico Microsof",
                  ProdutoId = 3,
                  OrdemProducaoId = 2,
                  Situacao = EnumOrdemServicoSituacao.EM_PRODUCAO
              },
              new OrdemServico
              {
                  OrdemServicoId = 4,
                  Descricao = "Servico Microsof",
                  ProdutoId = 4,
                  OrdemProducaoId = 2,
                  Situacao = EnumOrdemServicoSituacao.EM_PLANEJAMENTO
              }
            );
            mb.Entity<Produto>().HasData(
                new Produto
                {
                    ProdutoId = 1,
                    Descricao = "IPhone",
                    Quantidade = 5000,

                },
                new Produto
                {
                    ProdutoId = 2,
                    Descricao = "SmartPhone",
                    Quantidade = 1000,

                },
                new Produto
                {
                    ProdutoId = 3,
                    Descricao = "Windos",
                    Quantidade = 1000,

                },
                new Produto
                {
                    ProdutoId = 4,
                    Descricao = "XBOX",
                    Quantidade = 1000,

                }
            );
        }

    }



}