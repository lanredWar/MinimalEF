using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnSecuenciaTableTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Secuencia",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Secuencia",
                table: "Tarea");
        }
    }
}
