using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options) {}

        public DbSet<SistemaFinanceiro> SistemaFinanceiro { get; set; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Despesa> Despesa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // verifica se a string de conexão está configurada caso não ele pega a string local
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id); // Mapear a tabela AspNetUsers e a Model ApplicationUser
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=.\\SQLEXPRESS;Initial Catalog=FINANCEIRO_2023;Integrated Security=False;User ID=sa;Password=AAaa123#;Trust Server Certificate=true;MultipleActiveResultSets=true";
            //return "Data Source=.\\SQLEXPRESS;Initial Catalog=FINANCEIRO_2023;Integrated Security=True";
        }
    }
}
