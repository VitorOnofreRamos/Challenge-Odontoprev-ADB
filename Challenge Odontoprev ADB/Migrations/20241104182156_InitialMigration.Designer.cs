﻿// <auto-generated />
using System;
using Challenge_Odontoprev_ADB.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Challenge_Odontoprev_ADB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241104182156_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address_City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Address_State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Address_Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("AppointmentReason")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PatientId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("OdonPrev_Appointment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address_City = "São Paulo",
                            Address_State = "SP",
                            Address_Street = "Rua C, 789",
                            AppointmentDate = new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentReason = "Consulta inicial",
                            CreatedAt = new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3609),
                            DoctorId = 1,
                            PatientId = 1,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DoctorName");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DoctorPhone");

                    b.Property<int>("Speciality")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("OdonPrev_Doctor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CRM = "123456-78/SP",
                            CreatedAt = new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3451),
                            Name = "Dr. Teste",
                            Phone = "(11) 1234-5678",
                            Speciality = 0
                        });
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TIMESTAMP");

                    b.Property<int>("HealthCard")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("PatientName");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("PatientPhone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("OdonPrev_Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "123.456.789-00",
                            CreatedAt = new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3587),
                            DateOfBirth = new DateTime(1987, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HealthCard = 12345,
                            Name = "Paciente Teste",
                            Phone = "(11) 98765-4321"
                        });
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<float>("Cost")
                        .HasColumnType("BINARY_FLOAT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ProcedureDescription")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ProcedureType")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("OdonPrev_Treatment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            Cost = 200f,
                            CreatedAt = new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3626),
                            ProcedureDescription = "Limpeza dental completa",
                            ProcedureType = 0
                        });
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Appointment", b =>
                {
                    b.HasOne("Challenge_Odontoprev_ADB.Models.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge_Odontoprev_ADB.Models.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Treatment", b =>
                {
                    b.HasOne("Challenge_Odontoprev_ADB.Models.Entities.Appointment", "Appointment")
                        .WithMany("Treatments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Appointment", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Challenge_Odontoprev_ADB.Models.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}