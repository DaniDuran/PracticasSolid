using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ms_regis.infraestructuraPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Addcommenttotableuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                comment: "Campo clave",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                comment: "Campo nombre",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lastname",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                comment: "Campo apellido",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                comment: "Campo email de tipo unico",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthdate",
                schema: "system-lab",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Campo nombre",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "system-lab",
                table: "users",
                type: "integer",
                nullable: false,
                comment: "llave primaria",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Campo clave");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Campo nombre");

            migrationBuilder.AlterColumn<string>(
                name: "lastname",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Campo apellido");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "system-lab",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Campo email de tipo unico");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthdate",
                schema: "system-lab",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Campo nombre");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "system-lab",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "llave primaria")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
