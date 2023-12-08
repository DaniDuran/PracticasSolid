using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_regis.infraestructuraPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                schema: "system-lab",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_name_lastname",
                schema: "system-lab",
                table: "users",
                columns: new[] { "name", "lastname" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_email",
                schema: "system-lab",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_name_lastname",
                schema: "system-lab",
                table: "users");
        }
    }
}
