using LearningCore.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.Infra
{
    public class GerenciaEventosContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.\sqlexpress;Database=TesteHard;Trusted_Connection=True;", b => b.MigrationsAssembly("LearningCore"));
        }

        public DbSet<UsuarioMaster> UsuarioMaster { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioMaster>()
                .HasKey(p => p.IdUsuarioMaster);

            modelBuilder.Entity<Cliente>()
               .HasKey(p => p.IdCliente);

            modelBuilder.Entity<Projeto>()
                .HasKey(p => p.IdProjeto);
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Cliente);
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
