using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoef.Migrations
{
    /// <inheritdoc />
    public partial class RestriccionDescripccionFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260b"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 19, 20, 3, 41, 382, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260c"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 19, 20, 3, 41, 382, DateTimeKind.Local).AddTicks(480));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260b"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 19, 19, 51, 36, 378, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("40d79cef-73f1-4fe8-8a6c-168d99e4260c"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 19, 19, 51, 36, 378, DateTimeKind.Local).AddTicks(454));
        }
    }
}
