using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LearningCore.Infra;

namespace LearningCore.Migrations
{
    [DbContext(typeof(GerenciaEventosContext))]
    [Migration("20170501015214_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LearningCore.Domain.Entidades.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("DescricaoCliente");

                    b.Property<int?>("UsuarioMasterIdUsuarioMaster");

                    b.HasKey("IdCliente");

                    b.HasIndex("UsuarioMasterIdUsuarioMaster");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LearningCore.Domain.Entidades.Projeto", b =>
                {
                    b.Property<int>("IdProjeto")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteIdCliente");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("DescricaoProjeto");

                    b.HasKey("IdProjeto");

                    b.HasIndex("ClienteIdCliente");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("LearningCore.Domain.Entidades.UsuarioMaster", b =>
                {
                    b.Property<int>("IdUsuarioMaster")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("EmailUsuario");

                    b.Property<string>("SenhaUsuario");

                    b.HasKey("IdUsuarioMaster");

                    b.ToTable("UsuarioMaster");
                });

            modelBuilder.Entity("LearningCore.Domain.Entidades.Cliente", b =>
                {
                    b.HasOne("LearningCore.Domain.Entidades.UsuarioMaster", "UsuarioMaster")
                        .WithMany()
                        .HasForeignKey("UsuarioMasterIdUsuarioMaster");
                });

            modelBuilder.Entity("LearningCore.Domain.Entidades.Projeto", b =>
                {
                    b.HasOne("LearningCore.Domain.Entidades.Cliente", "Cliente")
                        .WithMany("Projetos")
                        .HasForeignKey("ClienteIdCliente");
                });
        }
    }
}
