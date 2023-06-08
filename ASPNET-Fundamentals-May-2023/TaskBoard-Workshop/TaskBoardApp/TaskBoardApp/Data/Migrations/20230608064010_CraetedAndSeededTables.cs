using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CraetedAndSeededTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2c99f2e-24f6-4096-a6c9-b5f4da1fb080", 0, "ade53ca5-fbd2-434f-8cc1-eda76be6e6c6", null, false, false, null, null, "TEST@GMAIL.COM", "AQAAAAEAACcQAAAAEMYV+/483XKjTjcMJ81zATbaB7vE31HkqiZFA2LhzWq3hcXcOXsIilA+0bWLuSfeXQ==", null, false, "b4a73d9b-aea1-4ce0-a939-5832a35c484e", false, "test@gmail.com" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 20, 9, 40, 10, 391, DateTimeKind.Local).AddTicks(8126), "Implement better styling for the home page", "c2c99f2e-24f6-4096-a6c9-b5f4da1fb080", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 8, 9, 40, 10, 391, DateTimeKind.Local).AddTicks(8165), "Create Android client app for the TaskBoard RESTful API", "c2c99f2e-24f6-4096-a6c9-b5f4da1fb080", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 8, 9, 40, 10, 391, DateTimeKind.Local).AddTicks(8169), "Create Desktop client app for the TaskBoard RESTful API", "c2c99f2e-24f6-4096-a6c9-b5f4da1fb080", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 8, 9, 40, 10, 391, DateTimeKind.Local).AddTicks(8171), "Implement 'Create Task' page for adding tasks through the browser", "c2c99f2e-24f6-4096-a6c9-b5f4da1fb080", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2c99f2e-24f6-4096-a6c9-b5f4da1fb080");
        }
    }
}
