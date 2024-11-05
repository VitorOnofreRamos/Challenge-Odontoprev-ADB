using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Challenge_Odontoprev_ADB.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdonPrev_Doctor",
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
                    table.PrimaryKey("PK_OdonPrev_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdonPrev_Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PatientName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
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
                name: "OdonPrev_Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AppointmentReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Address_Street = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address_City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address_State = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
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
                        name: "FK_OdonPrev_Appointment_OdonPrev_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "OdonPrev_Doctor",
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
                    Cost = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
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

            migrationBuilder.InsertData(
                table: "OdonPrev_Doctor",
                columns: new[] { "Id", "CRM", "CreatedAt", "DoctorName", "DoctorPhone", "Speciality", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123456-78/SP", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2395), "Dr. João Silva", "(11) 1234-5678", 0, null },
                    { 2, "234567-89/MG", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2405), "Dra. Maria Oliveira", "(11) 2345-6789", 8, null },
                    { 3, "345678-91/SP", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2407), "Dr. Paulo Lima", "(11) 34567-8910", 9, null }
                });

            migrationBuilder.InsertData(
                table: "OdonPrev_Patient",
                columns: new[] { "Id", "CPF", "CreatedAt", "DateOfBirth", "HealthCard", "PatientName", "PatientPhone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123.456.789-00", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2524), new DateTime(1987, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 12345, "Lucas Pereira", "(11) 98765-4321", null },
                    { 2, "234.555.779-20", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2527), new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22365, "Miguel Alves", "(11) 9455-4771", null },
                    { 3, "321.456.665-12", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2528), new DateTime(1998, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 87745, "Rafael Cardoso", "(11) 92775-5378", null }
                });

            migrationBuilder.InsertData(
                table: "OdonPrev_Appointment",
                columns: new[] { "Id", "Address_City", "Address_State", "Address_Street", "AppointmentDate", "AppointmentReason", "CreatedAt", "DoctorId", "PatientId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "São Paulo", "SP", "Rua A, 123", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2549), 1, 1, 0, null },
                    { 2, "Rio de Janeiro", "RJ", "Rua B, 456", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita de Emergência", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2551), 2, 2, 2, null },
                    { 3, "Fortaleza", "CE", "Rua C, 789", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extração dentária", new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2552), 3, 3, 1, null }
                });

            migrationBuilder.InsertData(
                table: "OdonPrev_Treatment",
                columns: new[] { "Id", "AppointmentId", "Cost", "CreatedAt", "ProcedureDescription", "ProcedureType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 200f, new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2570), "Limpeza dental completa", 0, null },
                    { 2, 2, 350f, new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2571), "Prenchimento", 7, null },
                    { 3, 3, 500f, new DateTime(2024, 11, 5, 14, 45, 35, 476, DateTimeKind.Local).AddTicks(2572), "Implantação de protese", 10, null }
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
                name: "OdonPrev_Doctor");

            migrationBuilder.DropTable(
                name: "OdonPrev_Patient");
        }
    }
}
