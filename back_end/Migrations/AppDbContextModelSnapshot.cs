﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back_end.Context;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("back_end.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Descricao = "Apple"
                        },
                        new
                        {
                            ClienteId = 2,
                            Descricao = "Microsoft"
                        });
                });

            modelBuilder.Entity("back_end.Models.Formulario", b =>
                {
                    b.Property<int>("FormularioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormularioId"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormularioId");

                    b.ToTable("Formularios");
                });

            modelBuilder.Entity("back_end.Models.OrdemProducao", b =>
                {
                    b.Property<int>("OrdemProducaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdemProducaoId"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("OrdemProducaoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("OrdemProducoes");

                    b.HasData(
                        new
                        {
                            OrdemProducaoId = 1,
                            ClienteId = 1,
                            Descricao = "Producao Apple",
                            ProdutoId = 1,
                            Situacao = 1
                        },
                        new
                        {
                            OrdemProducaoId = 2,
                            ClienteId = 2,
                            Descricao = "Producao Microsof",
                            ProdutoId = 3,
                            Situacao = 1
                        });
                });

            modelBuilder.Entity("back_end.Models.OrdemServico", b =>
                {
                    b.Property<int>("OrdemServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdemServicoId"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrdemProducaoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("OrdemServicoId");

                    b.HasIndex("OrdemProducaoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("OrdemServicos");

                    b.HasData(
                        new
                        {
                            OrdemServicoId = 1,
                            Descricao = "Servico Apple",
                            OrdemProducaoId = 1,
                            ProdutoId = 1,
                            Situacao = 1
                        },
                        new
                        {
                            OrdemServicoId = 2,
                            Descricao = "Servico Apple",
                            OrdemProducaoId = 1,
                            ProdutoId = 2,
                            Situacao = 1
                        },
                        new
                        {
                            OrdemServicoId = 3,
                            Descricao = "Servico Microsof",
                            OrdemProducaoId = 2,
                            ProdutoId = 3,
                            Situacao = 1
                        },
                        new
                        {
                            OrdemServicoId = 4,
                            Descricao = "Servico Microsof",
                            OrdemProducaoId = 2,
                            ProdutoId = 4,
                            Situacao = 1
                        });
                });

            modelBuilder.Entity("back_end.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            Descricao = "IPhone",
                            Quantidade = 5000
                        },
                        new
                        {
                            ProdutoId = 2,
                            Descricao = "SmartPhone",
                            Quantidade = 1000
                        },
                        new
                        {
                            ProdutoId = 3,
                            Descricao = "Windos",
                            Quantidade = 1000
                        },
                        new
                        {
                            ProdutoId = 4,
                            Descricao = "XBOX",
                            Quantidade = 1000
                        });
                });

            modelBuilder.Entity("back_end.Models.OrdemProducao", b =>
                {
                    b.HasOne("back_end.Models.Cliente", "Cliente")
                        .WithMany("OrdemProducoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_end.Models.Produto", "Produto")
                        .WithMany("OrdemProducoes")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("back_end.Models.OrdemServico", b =>
                {
                    b.HasOne("back_end.Models.OrdemProducao", "OrdemProducao")
                        .WithMany("OrdemServicos")
                        .HasForeignKey("OrdemProducaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_end.Models.Produto", "Produto")
                        .WithMany("OrdemServicos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrdemProducao");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("back_end.Models.Cliente", b =>
                {
                    b.Navigation("OrdemProducoes");
                });

            modelBuilder.Entity("back_end.Models.OrdemProducao", b =>
                {
                    b.Navigation("OrdemServicos");
                });

            modelBuilder.Entity("back_end.Models.Produto", b =>
                {
                    b.Navigation("OrdemProducoes");

                    b.Navigation("OrdemServicos");
                });
#pragma warning restore 612, 618
        }
    }
}