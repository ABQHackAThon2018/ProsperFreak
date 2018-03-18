using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreApp.Data.Migrations
{
    public partial class modelupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Payment",
                table: "Job",
                newName: "PaymentAmount");

            migrationBuilder.RenameColumn(
                name: "Food",
                table: "Job",
                newName: "FreeFood");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Job",
                newName: "Time");

            migrationBuilder.AddColumn<bool>(
                name: "Administrative",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutoMechanic",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableNow",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Construction",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomerService",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Foodprep",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Housework",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Landscaping",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Job",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Administrative",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AutoMechanic",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AvailableNow",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Construction",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CustomerService",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Foodprep",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Housework",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Landscaping",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Job",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "PaymentAmount",
                table: "Job",
                newName: "Payment");

            migrationBuilder.RenameColumn(
                name: "FreeFood",
                table: "Job",
                newName: "Food");
        }
    }
}
