using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioMaster",
                columns: table => new
                {
                    IdUsuarioMaster = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    EmailUsuario = table.Column<string>(nullable: true),
                    SenhaUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMaster", x => x.IdUsuarioMaster);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DescricaoCliente = table.Column<string>(nullable: true),
                    UsuarioMasterIdUsuarioMaster = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_UsuarioMaster_UsuarioMasterIdUsuarioMaster",
                        column: x => x.UsuarioMasterIdUsuarioMaster,
                        principalTable: "UsuarioMaster",
                        principalColumn: "IdUsuarioMaster",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    IdProjeto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteIdCliente = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DescricaoProjeto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.IdProjeto);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioMasterIdUsuarioMaster",
                table: "Clientes",
                column: "UsuarioMasterIdUsuarioMaster");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteIdCliente",
                table: "Projetos",
                column: "ClienteIdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "UsuarioMaster");
        }
    }
}
