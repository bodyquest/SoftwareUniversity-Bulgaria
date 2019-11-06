using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSystem.Data.Migrations
{
    public partial class CourseSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[] { 1, "Testing", new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "EF Framework", 0m, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ResourceId", "CourseId", "Name", "Type", "Url" },
                values: new object[] { 1, 1, "Presentation", 1, "www.studentsystem.my/presentation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);
        }
    }
}
