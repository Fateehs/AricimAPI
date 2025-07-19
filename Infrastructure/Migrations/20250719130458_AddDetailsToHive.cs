using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailsToHive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "HoneyAmount",
                table: "Hives",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeeBehavior",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CombCondition",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiseaseSymptoms",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedingStatus",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrameCount",
                table: "Hives",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HarvestedHoney",
                table: "Hives",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMarked",
                table: "Hives",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInspection",
                table: "Hives",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextInspection",
                table: "Hives",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pests",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "QueenBirthDate",
                table: "Hives",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QueenStatus",
                table: "Hives",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequeeningDate",
                table: "Hives",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeeBehavior",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "CombCondition",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "DiseaseSymptoms",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "FeedingStatus",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "FrameCount",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "HarvestedHoney",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "IsMarked",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Pests",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "QueenBirthDate",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "QueenStatus",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "RequeeningDate",
                table: "Hives");

            migrationBuilder.AlterColumn<double>(
                name: "HoneyAmount",
                table: "Hives",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
