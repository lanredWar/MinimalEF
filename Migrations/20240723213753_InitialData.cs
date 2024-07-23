using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Secuencia",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("588afe2f-48ba-4051-8c08-ff756b1c159e"), null, "Actividades Personales", 50 },
                    { new Guid("588afe2f-48ba-4051-8c09-ff756b1c151f"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Secuencia", "Titulo" },
                values: new object[,]
                {
                    { new Guid("588afe2f-48ba-3000-8c09-ff756b1c151f"), new Guid("588afe2f-48ba-4051-8c09-ff756b1c151f"), null, new DateTime(2024, 7, 23, 15, 37, 53, 741, DateTimeKind.Local).AddTicks(6807), 1, null, "Pago de servicios publicos" },
                    { new Guid("588afe2f-48ba-4000-8c08-ff756b1c159e"), new Guid("588afe2f-48ba-4051-8c08-ff756b1c159e"), null, new DateTime(2024, 7, 23, 15, 37, 53, 741, DateTimeKind.Local).AddTicks(6826), 0, null, "Terminar de ver peliculas en Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("588afe2f-48ba-3000-8c09-ff756b1c151f"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("588afe2f-48ba-4000-8c08-ff756b1c159e"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("588afe2f-48ba-4051-8c08-ff756b1c159e"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("588afe2f-48ba-4051-8c09-ff756b1c151f"));

            migrationBuilder.AlterColumn<string>(
                name: "Secuencia",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
