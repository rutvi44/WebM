using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidTerm.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.ProjectId);
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "ProjectId", "ProjectDate", "ProjectDuration", "ProjectName" },
                values: new object[] { 1, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "New Build" });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "ProjectId", "ProjectDate", "ProjectDuration", "ProjectName" },
                values: new object[] { 2, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Bug Fix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");
        }
    }
}
