using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sat.Recruitment.DataAccess.Migrations
{
    public partial class FixToAudith : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTimeSpan",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteTimeSpan",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedTimeSpan",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Users");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CreateTimeSpan",
                table: "Users",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DeleteTimeSpan",
                table: "Users",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "UpdatedTimeSpan",
                table: "Users",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
