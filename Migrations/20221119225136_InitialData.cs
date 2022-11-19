using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260a"), "Tareas de trabajo", "Trabajo", 1 },
                    { new Guid("40d79cef-73f1-4fe8-8a6c-168d99e426bc"), "Tareas personales", "Personal", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260b"), new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260a"), "Tarea 1 de trabajo", new DateTime(2022, 11, 19, 19, 51, 36, 378, DateTimeKind.Local).AddTicks(442), 0, "Tarea 1" },
                    { new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260c"), new Guid("40d79cef-73f1-4fe8-8a6c-168d99e426bc"), "Tarea 2 personal", new DateTime(2022, 11, 19, 19, 51, 36, 378, DateTimeKind.Local).AddTicks(454), 1, "Tarea 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260b"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260a"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e426bc"));
        }
    }
}
