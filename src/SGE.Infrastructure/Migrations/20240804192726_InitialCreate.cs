using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDismissed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subscription_SubscriptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DismissedReminderIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalendarDictionary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessProcedure",
                columns: table => new
                {
                    ProcedureId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcessId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessProcedure", x => new { x.ProcedureId, x.ProcessId });
                    table.ForeignKey(
                        name: "FK_ProcessProcedure_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessProcedure_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b106bb0d-d2ad-4b56-b644-8fa514c8d3b7", "Modificaciones de parametros técnicos" },
                    { "d9a6b405-d552-4792-8ec5-588647ee9b67", "Otorgamiento de frecuenias" }
                });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "Name" },
                values: new object[] { "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe", null, false, "Televisión" });

            migrationBuilder.InsertData(
                table: "ProcessProcedure",
                columns: new[] { "ProcedureId", "ProcessId" },
                values: new object[,]
                {
                    { "b106bb0d-d2ad-4b56-b644-8fa514c8d3b7", "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe" },
                    { "d9a6b405-d552-4792-8ec5-588647ee9b67", "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessProcedure_ProcessId",
                table: "ProcessProcedure",
                column: "ProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessProcedure");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Processes");
        }
    }
}
