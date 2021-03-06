// <auto-generated />
using System;
using Ebd.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ebd.Infra.Data.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("ResponsavelId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.AvaliacaoAluno", b =>
                {
                    b.Property<int>("AvaliacaoAlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("AvaliacaoId")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoAlunoId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("AvaliacaoId");

                    b.ToTable("AvaliacaoAluno");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Bairro", b =>
                {
                    b.Property<int>("BairroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("BairroId");

                    b.HasIndex("Nome");

                    b.ToTable("Bairro");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Chamada", b =>
                {
                    b.Property<int>("ChamadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EstavaPresente")
                        .HasColumnType("bit");

                    b.Property<int>("LicaoId")
                        .HasColumnType("int");

                    b.HasKey("ChamadaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("LicaoId");

                    b.ToTable("Chamada");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ContatoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BairroId")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.HasIndex("BairroId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Licao", b =>
                {
                    b.Property<int>("LicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RevistaId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("LicaoId");

                    b.HasIndex("RevistaId");

                    b.ToTable("Licao");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("NascidoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("WhatsappIgualCelular")
                        .HasColumnType("bit");

                    b.HasKey("PessoaId");

                    b.HasIndex("Nome");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Revista", b =>
                {
                    b.Property<int>("RevistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Sumario")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Trimestre")
                        .HasColumnType("int");

                    b.HasKey("RevistaId");

                    b.HasIndex("Ano", "Trimestre");

                    b.ToTable("Revista");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdadeMaxima")
                        .HasColumnType("int");

                    b.Property<int>("IdadeMinima")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("TurmaId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Aluno", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Pessoa", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId");

                    b.HasOne("Ebd.Domain.Core.Entities.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Responsavel");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.AvaliacaoAluno", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Aluno", "Aluno")
                        .WithMany("AvaliacoesAluno")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Avaliacao", "Avaliacao")
                        .WithMany("AvaliacoesAluno")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Chamada", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Licao", "Licao")
                        .WithMany()
                        .HasForeignKey("LicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Licao");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Contato", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Endereco", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Bairro", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bairro");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Licao", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Revista", "Revista")
                        .WithMany("Licoes")
                        .HasForeignKey("RevistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revista");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Professor", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Turma", "Turma")
                        .WithMany("Professores")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Aluno", b =>
                {
                    b.Navigation("AvaliacoesAluno");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Avaliacao", b =>
                {
                    b.Navigation("AvaliacoesAluno");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Pessoa", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Revista", b =>
                {
                    b.Navigation("Licoes");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Professores");
                });
#pragma warning restore 612, 618
        }
    }
}
