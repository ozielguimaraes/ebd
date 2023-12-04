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
            ConfigurePostgresConnection(builder)
            //ConfigureMySqlConnection()
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory());
            //builder.UseLazyLoadingProxies(false);

            base.OnConfiguring(builder);
        }

        private DbContextOptionsBuilder ConfigurePostgresConnection(DbContextOptionsBuilder builder)
        {
            var connection1 = appConfiguration.GetConnectionString("DefaultConnection");
            Debug.WriteLine("DefaultConnection");
            Debug.WriteLine(connection1);

            var connection2 = appConfiguration.GetConnectionString("CUSTOMCONNSTR_DefaultConnection");
            Debug.WriteLine("CUSTOMCONNSTR_DefaultConnection");
            Debug.WriteLine(connection2);

            var connection3 = appConfiguration.GetConnectionString("POSTGRESQLCONNSTR_DefaultConnection");
            Debug.WriteLine("POSTGRESQLCONNSTR_DefaultConnection");
            Debug.WriteLine(connection3);
            var connection = connection1 ?? connection2 ?? connection3 ?? Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DefaultConnection") ?? Environment.GetEnvironmentVariable("CUSTOMCONNSTR_DefaultConnection");

            if (connection is null)
                throw new ArgumentNullException("Conexão nula");

            builder.UseNpgsql(connection, npgsqlOptions =>
            {
                if (Configuration.RetryOnFailure.Enable)
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: Configuration.RetryOnFailure.RetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(Configuration.RetryOnFailure.MaxTimeOutInSeconds),
                        errorCodesToAdd: null);
                }
            });

            return builder;
        }

        private DbContextOptionsBuilder ConfigureMySqlConnection(DbContextOptionsBuilder builder)
        {
            var serverVersion = new MySqlServerVersion(Configuration.MySql.Version);
            builder.UseMySql(appConfiguration.GetConnectionString("DefaultConnection"), serverVersion);

            return builder;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
