using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Challenge_Odontoprev_ADB.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.InsertData(
                table: "OdonPrev_Doctor",
                columns: new[] { "Id", "CRM", "CreatedAt", "DoctorName", "DoctorPhone", "Speciality", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "456789-12/SP", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5416), "Dra. Ana Costa", "(11) 3567-8910", 1, null },
                    { 5, "567890-23/MG", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5419), "Dr. Gabriel Souza", "(11) 4678-9012", 2, null },
                    { 6, "678901-34/RJ", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5422), "Dra. Carla Fernandes", "(11) 5789-0123", 5, null },
                    { 7, "789012-45/SP", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5424), "Dr. Ricardo Costa", "(11) 6890-1234", 4, null },
                    { 8, "890123-56/MG", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5427), "Dr. Felipe Martins", "(11) 7901-2345", 6, null },
                    { 9, "901234-67/SP", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5429), "Dra. Juliana Pereira", "(11) 8912-3456", 3, null },
                    { 10, "123456-78/RJ", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5432), "Dr. Marcos Oliveira", "(11) 9123-4567", 11, null }
                });

            migrationBuilder.UpdateData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.InsertData(
                table: "OdonPrev_Patient",
                columns: new[] { "Id", "CPF", "CreatedAt", "DateOfBirth", "HealthCard", "PatientName", "PatientPhone", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "432.123.567-89", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5809), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 33565, "Beatriz Silva", "(11) 92928-5747", null },
                    { 5, "543.876.987-10", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5812), new DateTime(1989, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 77345, "Daniel Costa", "(11) 93718-9223", null },
                    { 6, "654.789.876-34", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5815), new DateTime(2001, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 12943, "Fernanda Gomes", "(11) 94576-5348", null },
                    { 7, "765.432.098-76", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5818), new DateTime(1990, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 34985, "João Silva", "(11) 91234-7645", null },
                    { 8, "876.543.210-21", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5821), new DateTime(1992, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 22345, "Carla Oliveira", "(11) 92347-8823", null },
                    { 9, "987.654.321-32", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5824), new DateTime(1985, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 66782, "Paulo Santos", "(11) 93452-7123", null },
                    { 10, "109.876.543-21", new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5827), new DateTime(1997, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 99877, "Larissa Pereira", "(11) 93467-5432", null }
                });

            migrationBuilder.UpdateData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.InsertData(
                table: "OdonPrev_Treatment",
                columns: new[] { "Id", "Cost", "CreatedAt", "ProcedureDescription", "ProcedureType", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, 250f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5899), "Extração de dente", 2, null },
                    { 5, 450f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5901), "Canal radicular", 3, null },
                    { 6, 700f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5904), "Coroa dentária", 4, null },
                    { 7, 800f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5906), "Prótese dentária", 5, null },
                    { 8, 1200f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5908), "Implante dentário", 6, null },
                    { 9, 1500f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5911), "Tratamento ortodôntico", 7, null },
                    { 10, 400f, new DateTime(2025, 2, 28, 19, 17, 56, 58, DateTimeKind.Local).AddTicks(5913), "Tratamento periodontal", 8, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Patient",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "OdonPrev_Treatment",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 5, 17, 35, 51, 516, DateTimeKind.Local).AddTicks(9911));
        }
    }
}
