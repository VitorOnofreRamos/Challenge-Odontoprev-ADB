﻿// <auto-generated />
using System;
using Challenge_Odontoprev_ADB.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Challenge_Odontoprev_ADB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("SEQ_CONSULTA");

            modelBuilder.HasSequence("SEQ_DENTISTA");

            modelBuilder.HasSequence("SEQ_HISTORICO");

            modelBuilder.HasSequence("SEQ_PACIENTE");

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Consulta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_CONSULTA")
                        .HasDefaultValueSql("SEQ_DENTISTA.NEXTVAL");

                    b.Property<DateTime>("Data_Consulta")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_CONSULTA");

                    b.Property<long>("ID_Dentista")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_DENTISTA");

                    b.Property<long>("ID_Paciente")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_PACIENTE");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("ID_Dentista");

                    b.HasIndex("ID_Paciente");

                    b.ToTable("CONSULTA");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Dentista", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_DENTISTA")
                        .HasDefaultValueSql("SEQ_DENTISTA.NEXTVAL");

                    b.Property<string>("CRO")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("CRO");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("ESPECIALIDADE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.ToTable("DENTISTA");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.HistoricoConsulta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_HISTORICO")
                        .HasDefaultValueSql("SEQ_HISTORICO.NEXTVAL");

                    b.Property<DateTime>("Data_Atendimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_ATENDIMENTO");

                    b.Property<long>("ID_Consulta")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_CONSULTA");

                    b.Property<string>("Motivo_Consulta")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR2(300)")
                        .HasColumnName("MOTIVO_CONSULTA");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR2(300)")
                        .HasColumnName("OBSERVACOES");

                    b.HasKey("Id");

                    b.HasIndex("ID_Consulta");

                    b.ToTable("HISTORICO_CONSULTA");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Paciente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_PACIENTE")
                        .HasDefaultValueSql("SEQ_PACIENTE.NEXTVAL");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("NVARCHAR2(14)")
                        .HasColumnName("CPF");

                    b.Property<long>("Carteirinha")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("CARTEIRINHA");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.ToTable("PACIENTE");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Consulta", b =>
                {
                    b.HasOne("Challenge_Odontoprev_ADB.Models.Entities.Dentista", "Dentista")
                        .WithMany("Consultas")
                        .HasForeignKey("ID_Dentista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge_Odontoprev_ADB.Models.Entities.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("ID_Paciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentista");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.HistoricoConsulta", b =>
                {
                    b.HasOne("Challenge_Odontoprev_ADB.Models.Entities.Consulta", "Consulta")
                        .WithMany("Historicos")
                        .HasForeignKey("ID_Consulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Consulta", b =>
                {
                    b.Navigation("Historicos");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Dentista", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
