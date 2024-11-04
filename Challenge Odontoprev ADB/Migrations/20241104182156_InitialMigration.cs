using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                values: new object[] { 1, "123456-78/SP", new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3451), "Dr. Teste", "(11) 1234-5678", 0, null });

            migrationBuilder.InsertData(
                table: "OdonPrev_Patient",
                columns: new[] { "Id", "CPF", "CreatedAt", "DateOfBirth", "HealthCard", "PatientName", "PatientPhone", "UpdatedAt" },
                values: new object[] { 1, "123.456.789-00", new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3587), new DateTime(1987, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 12345, "Paciente Teste", "(11) 98765-4321", null });

            migrationBuilder.InsertData(
                table: "OdonPrev_Appointment",
                columns: new[] { "Id", "Address_City", "Address_State", "Address_Street", "AppointmentDate", "AppointmentReason", "CreatedAt", "DoctorId", "PatientId", "Status", "UpdatedAt" },
                values: new object[] { 1, "São Paulo", "SP", "Rua C, 789", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta inicial", new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3609), 1, 1, 0, null });

            migrationBuilder.InsertData(
                table: "OdonPrev_Treatment",
                columns: new[] { "Id", "AppointmentId", "Cost", "CreatedAt", "ProcedureDescription", "ProcedureType", "UpdatedAt" },
                values: new object[] { 1, 1, 200f, new DateTime(2024, 11, 4, 15, 21, 56, 281, DateTimeKind.Local).AddTicks(3626), "Limpeza dental completa", 0, null });

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
