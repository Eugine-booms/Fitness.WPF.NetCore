using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.DAL.Migrations
{
    public partial class Goal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Fats",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NutritionId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSteps = table.Column<int>(type: "int", nullable: false),
                    GoalForTheWeek = table.Column<double>(type: "float", nullable: false),
                    DesiredWeight = table.Column<double>(type: "float", nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    ActivityLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutritions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proteins = table.Column<double>(type: "float", nullable: false),
                    Fats = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutritions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GoalId",
                table: "Users",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_NutritionId",
                table: "Dishes",
                column: "NutritionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Nutritions_NutritionId",
                table: "Dishes",
                column: "NutritionId",
                principalTable: "Nutritions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Goals_GoalId",
                table: "Users",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Nutritions_NutritionId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Goals_GoalId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Nutritions");

            migrationBuilder.DropIndex(
                name: "IX_Users_GoalId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_NutritionId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "Dishes");

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrates",
                table: "Dishes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fats",
                table: "Dishes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Proteins",
                table: "Dishes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
