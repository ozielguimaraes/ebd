using Ebd.Domain.Core.Entities;
using Ebd.Infra.Data.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
            //ConfigurePostgresConnection(builder)
            //ConfigureMySqlConnection(builder)
            ConfigureSqlServerConnection(builder)
                .LogTo(message => Debug.WriteLine(message), LogLevel.Debug)
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory());
            //builder.UseLazyLoadingProxies(false);

            base.OnConfiguring(builder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");

            base.ConfigureConventions(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private DbContextOptionsBuilder ConfigureSqlServerConnection(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(appConfiguration.GetConnectionString("SqlServer"), options =>
            {
                if (Configuration.RetryOnFailure.Enable)
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: Configuration.RetryOnFailure.RetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(Configuration.RetryOnFailure.MaxTimeOutInSeconds),
                        errorNumbersToAdd: null);
                }
            });

            return builder;
        }
        private DbContextOptionsBuilder ConfigureMySqlConnection(DbContextOptionsBuilder builder)
        {
            const int tableDoesNotExist = 1146;
            const int tooManyConnections = 1040;
            const int accessDenied = 1145;
            const int syntaxError = 1064;
            const int mySqlServerConnectionClosed = 2006;
            const int outOfMemory = 2008;
            const int lostConnectionDuringQuery = 2013;

            var connectionString = appConfiguration.GetConnectionString("MySql");
            var serverVersion = new MySqlServerVersion(Configuration.MySql.Version);
            Debug.WriteLine(connectionString);
            builder.UseMySql(connectionString, serverVersion, options =>
            {
                if (Configuration.RetryOnFailure.Enable)
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: Configuration.RetryOnFailure.RetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(Configuration.RetryOnFailure.MaxTimeOutInSeconds),
                        errorNumbersToAdd: new int[7] { tableDoesNotExist, tooManyConnections, accessDenied, syntaxError, mySqlServerConnectionClosed, outOfMemory, lostConnectionDuringQuery });
                }
            });

            return builder;
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
            var connection = connection1 ?? connection2 ?? connection3
                ?? Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DefaultConnection")
                ?? Environment.GetEnvironmentVariable("CUSTOMCONNSTR_DefaultConnection")
                ?? Environment.GetEnvironmentVariable("AZURE_POSTGRESQL_CONNECTIONSTRING");

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
    }

    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }

    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        {
        }
    }

    public class TimeOnlyComparer : ValueComparer<TimeOnly>
    {
        public TimeOnlyComparer() : base(
            (t1, t2) => t1.Ticks == t2.Ticks,
            t => t.GetHashCode())
        {
        }
    }

    /// <summary>
    /// Converts <see cref="DateOnly?" /> to <see cref="DateTime?"/> and vice versa.
    /// </summary>
    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public NullableDateOnlyConverter() : base(
            d => d == null
                ? null
                : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
            d => d == null
                ? null
                : new DateOnly?(DateOnly.FromDateTime(d.Value)))
        { }
    }
}
