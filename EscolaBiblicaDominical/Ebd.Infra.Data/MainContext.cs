using Ebd.Domain.Core.Entities;
using Ebd.Infra.Data.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Ebd.Infra.Data
{
    public class MainContext : DbContext, IEntityFrameworkContext, IDisposable
    {
        private IConfiguration appConfiguration;

        public MainContext(DataBaseConfiguration configuration, IConfiguration appConfiguration)
        {
            this.appConfiguration = appConfiguration;
            Configuration = configuration;
            Database.SetCommandTimeout(Configuration.TimeoutInSeconds);
        }

        public DataBaseConfiguration Configuration { get; }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<AvaliacaoAluno> AvaliacaoAlunos { get; set; }
        public virtual DbSet<Avaliacao> Avaliacoes { get; set; }
        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Chamada> Chamadas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Licao> Licoes { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Revista> Revistas { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }

        public DatabaseFacade GetDatabase()
        {
            return base.Database;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var adas = appConfiguration.GetConnectionString("DefaultConnection");
            Debug.WriteLine("DefaultConnection");
            Debug.WriteLine(adas);

            var basdas = appConfiguration.GetConnectionString("CUSTOMCONNSTR_DefaultConnection");
            Debug.WriteLine("CUSTOMCONNSTR_DefaultConnection");
            Debug.WriteLine(basdas);

            var casdas = appConfiguration.GetConnectionString("POSTGRESQLCONNSTR_DefaultConnection");
            Debug.WriteLine("POSTGRESQLCONNSTR_DefaultConnection");
            Debug.WriteLine(casdas);

            builder.UseNpgsql(appConfiguration.GetConnectionString("POSTGRESQLCONNSTR_DefaultConnection"), npgsqlOptions =>
                {
                    if (Configuration.RetryOnFailure.Enable)
                    {
                        npgsqlOptions.EnableRetryOnFailure(
                            maxRetryCount: Configuration.RetryOnFailure.RetryCount,
                            maxRetryDelay: TimeSpan.FromSeconds(Configuration.RetryOnFailure.MaxTimeOutInSeconds),
                            errorCodesToAdd: null);
                    }
                })
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory());

            //builder.UseLazyLoadingProxies(false);

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
