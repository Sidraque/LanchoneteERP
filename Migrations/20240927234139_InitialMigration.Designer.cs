﻿// <auto-generated />
using System;
using LanchoneteCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LanchoneteCore.Migrations
{
    [DbContext(typeof(LanchoneteCoreContext))]
    [Migration("20240927234139_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("LanchoneteCore.Models.Atendente", b =>
                {
                    b.Property<int>("AtendenteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("AtendenteID");

                    b.ToTable("Atendente");
                });

            modelBuilder.Entity("LanchoneteCore.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarrinhoCompraItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CarrinhoCompraID")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoCompraItemID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("CarrinhoCompraItem");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("ClienteID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AtendenteID")
                        .HasColumnType("int");

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Hora")
                        .HasColumnType("longtext");

                    b.Property<string>("Statusp")
                        .HasColumnType("longtext");

                    b.Property<double>("ValorAtual")
                        .HasColumnType("double");

                    b.HasKey("PedidoID");

                    b.HasIndex("AtendenteID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("LanchoneteCore.Models.PedidoDetalhe", b =>
                {
                    b.Property<int>("PedidoDetalheID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PedidoID")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("PedidoDetalheID");

                    b.HasIndex("PedidoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("PedidoDetalhe");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Disponibilidade")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("double");

                    b.HasKey("ProdutoID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("LanchoneteCore.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("LanchoneteCore.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Pedido", b =>
                {
                    b.HasOne("LanchoneteCore.Models.Atendente", "Atendente")
                        .WithMany("Pedidos")
                        .HasForeignKey("AtendenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanchoneteCore.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LanchoneteCore.Models.PedidoDetalhe", b =>
                {
                    b.HasOne("LanchoneteCore.Models.Pedido", "Pedido")
                        .WithMany("ListaPedidoDetalhe")
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanchoneteCore.Models.Produto", "Produto")
                        .WithMany("ListaPedidoDetalhe")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Atendente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Pedido", b =>
                {
                    b.Navigation("ListaPedidoDetalhe");
                });

            modelBuilder.Entity("LanchoneteCore.Models.Produto", b =>
                {
                    b.Navigation("ListaPedidoDetalhe");
                });
#pragma warning restore 612, 618
        }
    }
}
