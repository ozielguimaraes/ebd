﻿// <auto-generated />
using System;
using Ebd.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ebd.Infra.Data.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoId"), 1L, 1);

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

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoId");

                    b.ToTable("Avaliacao", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.AvaliacaoAluno", b =>
                {
                    b.Property<int>("AvaliacaoAlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoAlunoId"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<int>("LicaoId")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoAlunoId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("AvaliacaoId");

                    b.HasIndex("LicaoId");

                    b.ToTable("AvaliacaoAluno", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Bairro", b =>
                {
                    b.Property<int>("BairroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BairroId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("BairroId");

                    b.HasIndex("Nome");

                    b.ToTable("Bairro", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Chamada", b =>
                {
                    b.Property<int>("ChamadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChamadaId"), 1L, 1);

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

                    b.ToTable("Chamada", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContatoId"), 1L, 1);

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

                    b.ToTable("Contato", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"), 1L, 1);

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

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Licao", b =>
                {
                    b.Property<int>("LicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LicaoId"), 1L, 1);

                    b.Property<int>("RevistaId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("LicaoId");

                    b.HasIndex("RevistaId");

                    b.ToTable("Licao", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"), 1L, 1);

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

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessorId"), 1L, 1);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Professor", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Revista", b =>
                {
                    b.Property<int>("RevistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RevistaId"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("RemoverDepois")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sumario")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Trimestre")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("RevistaId");

                    b.HasIndex("TurmaId");

                    b.HasIndex("Ano", "Trimestre");

                    b.ToTable("Revista", (string)null);
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurmaId"), 1L, 1);

                    b.Property<int>("IdadeMaxima")
                        .HasColumnType("int");

                    b.Property<int>("IdadeMinima")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("TurmaId");

                    b.ToTable("Turma", (string)null);
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
                        .WithMany()
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
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Avaliacao", "Avaliacao")
                        .WithMany("AvaliacoesAluno")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ebd.Domain.Core.Entities.Licao", "Licao")
                        .WithMany("AvaliacoesAluno")
                        .HasForeignKey("LicaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Avaliacao");

                    b.Navigation("Licao");
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
                        .OnDelete(DeleteBehavior.NoAction)
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
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Revista", b =>
                {
                    b.HasOne("Ebd.Domain.Core.Entities.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("Ebd.Domain.Core.Entities.Licao", b =>
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
#pragma warning restore 612, 618
        }
    }
}
