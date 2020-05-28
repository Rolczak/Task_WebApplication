using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZadanieRekrutacja.Migrations
{
    public partial class AddEmployeeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    PerformanceManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_PerformanceManagerId",
                        column: x => x.PerformanceManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[] { 1, new DateTime(2015, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[] { 11, new DateTime(2013, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mateusz", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[] { 12, new DateTime(2017, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiesław", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[] { 2, new DateTime(2012, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[] { 3, new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrzej", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[,]
                {
                    { 4, new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piotr", 2 },
                    { 5, new DateTime(2011, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarzyna", 2 },
                    { 6, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbara", 2 },
                    { 8, new DateTime(2009, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zofia", 2 },
                    { 10, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", 3 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "PerformanceManagerId" },
                values: new object[,]
                {
                    { 7, new DateTime(2015, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ewa", 4 },
                    { 9, new DateTime(2018, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marian", 5 },
                    { 13, new DateTime(2013, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edyta", 10 },
                    { 14, new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrycja", 10 },
                    { 15, new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomasz", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PerformanceManagerId",
                table: "Employees",
                column: "PerformanceManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
