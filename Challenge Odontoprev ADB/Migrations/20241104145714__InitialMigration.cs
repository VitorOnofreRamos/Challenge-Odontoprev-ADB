using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_Odontoprev_ADB.Migrations
{
    /// <inheritdoc />
    public partial class _InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdonPrev_Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PatientName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateOfBirth_Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address_Street = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address_City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address_State = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PatientPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HealthCard = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdonPrev_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdonPrevDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DoctorName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CRM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Speciality = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DoctorPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdonPrevDoctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdonPrev_Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AppointmentReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Street = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    AppointmentDate_Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PatientId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DoctorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdonPrev_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdonPrev_Appointment_OdonPrevDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "OdonPrevDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdonPrev_Appointment_OdonPrev_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "OdonPrev_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdonPrev_Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProcedureType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProcedureDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppointmentId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdonPrev_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdonPrev_Treatment_OdonPrev_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "OdonPrev_Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdonPrev_Appointment_DoctorId",
                table: "OdonPrev_Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_OdonPrev_Appointment_PatientId",
                table: "OdonPrev_Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OdonPrev_Treatment_AppointmentId",
                table: "OdonPrev_Treatment",
                column: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdonPrev_Treatment");

            migrationBuilder.DropTable(
                name: "OdonPrev_Appointment");

            migrationBuilder.DropTable(
                name: "OdonPrevDoctor");

            migrationBuilder.DropTable(
                name: "OdonPrev_Patient");
        }
    }
}
