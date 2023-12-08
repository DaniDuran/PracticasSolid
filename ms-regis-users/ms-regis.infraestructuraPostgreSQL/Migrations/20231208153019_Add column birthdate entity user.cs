using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_regis.infraestructuraPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Addcolumnbirthdateentityuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthdate",
                schema: "system-lab",
                table: "users",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthdate",
                schema: "system-lab",
                table: "users");
        }
    }
}
