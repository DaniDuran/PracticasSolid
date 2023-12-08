using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_regis.infraestructuraSQLServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "system-lab");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "system-lab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loginrecords",
                schema: "system-lab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Access = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginrecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loginrecords_users_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "system-lab",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_loginrecords_IdUser",
                schema: "system-lab",
                table: "loginrecords",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                schema: "system-lab",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Name_LastName",
                schema: "system-lab",
                table: "users",
                columns: new[] { "Name", "LastName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loginrecords",
                schema: "system-lab");

            migrationBuilder.DropTable(
                name: "users",
                schema: "system-lab");
        }
    }
}
