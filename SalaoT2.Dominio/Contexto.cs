using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoT2.Dominio
{
    public class Contexto : DbContext
    {
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<MinhaBaseAgendamento> MinhaBaseAgendamento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<MinhaBaseClientes> MinhaBaseClientes { get; set; }
        public DbSet<Financeiro> Financeiro { get; set; }
        public DbSet<MinhaBaseFincanceira> MinhaBaseFincanceira { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<MinhaBaseFuncionarios> MinhaBaseFuncionarios { get; set; }
        public DbSet<MinhaBaseServicos> MinhaBaseServicos { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ServicoSolicitado> ServicoSolicitado { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Turno> Turno { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7LVNARC\\SQLEXPRESS; Database=SalaoT2; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
