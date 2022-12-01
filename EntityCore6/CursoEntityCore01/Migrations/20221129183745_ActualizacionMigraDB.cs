using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore01.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionMigraDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(name: "Categoria_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleUsuario",
                columns: table => new
                {
                    DetalleUsuarioId = table.Column<int>(name: "DetalleUsuario_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mascota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleUsuario", x => x.DetalleUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Etiqueta",
                columns: table => new
                {
                    EtiquetaId = table.Column<int>(name: "Etiqueta_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiqueta", x => x.EtiquetaId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Articulo",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(name: "Articulo_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Calificacion = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<int>(name: "Categoria_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Articulo", x => x.ArticuloId);
                    table.ForeignKey(
                        name: "FK_Tbl_Articulo_Categoria_Categoria_Id",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Categoria_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleUsuarioId = table.Column<int>(name: "DetalleUsuario_Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_DetalleUsuario_DetalleUsuario_Id",
                        column: x => x.DetalleUsuarioId,
                        principalTable: "DetalleUsuario",
                        principalColumn: "DetalleUsuario_Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(name: "Articulo_Id", type: "int", nullable: false),
                    EtiquetaId = table.Column<int>(name: "Etiqueta_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.EtiquetaId, x.ArticuloId });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id",
                        column: x => x.EtiquetaId,
                        principalTable: "Etiqueta",
                        principalColumn: "Etiqueta_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                        column: x => x.ArticuloId,
                        principalTable: "Tbl_Articulo",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Categoria_Id", "Activo", "FechaCreacion", "Nombre" },
                values: new object[] { 34, false, new DateTime(2021, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoría 6" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Articulo_Categoria_Id",
                table: "Tbl_Articulo",
                column: "Categoria_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DetalleUsuario_Id",
                table: "Usuario",
                column: "DetalleUsuario_Id",
                unique: true,
                filter: "[DetalleUsuario_Id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Etiqueta");

            migrationBuilder.DropTable(
                name: "Tbl_Articulo");

            migrationBuilder.DropTable(
                name: "DetalleUsuario");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
