using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vivero_G4.Migrations
{
    public partial class ViveroContextContextViveroDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Contenidos",
                columns: table => new
                {
                    ContenidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenidos", x => x.ContenidoId);
                    table.ForeignKey(
                        name: "FK_Contenidos_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viveros",
                columns: table => new
                {
                    ViveroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viveros", x => x.ViveroId);
                    table.ForeignKey(
                        name: "FK_Viveros_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(nullable: true),
                    ContenidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Contenidos_ContenidoId",
                        column: x => x.ContenidoId,
                        principalTable: "Contenidos",
                        principalColumn: "ContenidoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    EsAdmin = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ViveroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Viveros_ViveroId",
                        column: x => x.ViveroId,
                        principalTable: "Viveros",
                        principalColumn: "ViveroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroTarjeta = table.Column<long>(nullable: false),
                    FecVencimiento = table.Column<DateTime>(nullable: false),
                    CodSeguridad = table.Column<int>(nullable: false),
                    Domicilio = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    TipoEntrega = table.Column<int>(nullable: false),
                    ViveroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Viveros_ViveroId",
                        column: x => x.ViveroId,
                        principalTable: "Viveros",
                        principalColumn: "ViveroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<float>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Categoria = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    VentaId = table.Column<int>(nullable: true),
                    ViveroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                    table.ForeignKey(
                        name: "FK_Articulos_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Viveros_ViveroId",
                        column: x => x.ViveroId,
                        principalTable: "Viveros",
                        principalColumn: "ViveroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_UsuarioId",
                table: "Articulos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_VentaId",
                table: "Articulos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_ViveroId",
                table: "Articulos",
                column: "ViveroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ContenidoId",
                table: "Comentarios",
                column: "ContenidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contenidos_BlogId",
                table: "Contenidos",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ViveroId",
                table: "Usuario",
                column: "ViveroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ViveroId",
                table: "Ventas",
                column: "ViveroId");

            migrationBuilder.CreateIndex(
                name: "IX_Viveros_BlogId",
                table: "Viveros",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Contenidos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Viveros");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
