using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitutoMVC.Migrations
{
    public partial class ActualizacionModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Alumnos_AlumnoId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_AlumnoId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Cursos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlumnoId",
                table: "Cursos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AlumnoId",
                table: "Cursos",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Alumnos_AlumnoId",
                table: "Cursos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
