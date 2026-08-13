using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquivoWinchester.Infra.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Cacadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCacador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegiaoBaseCacador = table.Column<string>(type: "varchar(20)", nullable: false),
                    EspecialidadeCacador = table.Column<string>(type: "varchar(20)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anotacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StatusCacador = table.Column<string>(type: "varchar(20)", nullable: false),
                    Papel = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cacadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_SeresSobrenaturais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEntidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CacadorCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CacadorAtualizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Contramedida = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NivelRiscoSerSobrenatural = table.Column<string>(type: "varchar(20)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SinaisComuns = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StatusSerSobrenatural = table.Column<string>(type: "varchar(20)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SeresSobrenaturais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SeresSobrenaturais_TB_Cacadores_CacadorCriadorId",
                        column: x => x.CacadorCriadorId,
                        principalTable: "TB_Cacadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Cacadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CacadorCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CacadorAtualizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusCacada = table.Column<string>(type: "varchar(20)", nullable: false),
                    DificuldadeCacada = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SerSobrenaturalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DataCacada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cacadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Cacadas_TB_Cacadores_CacadorCriadorId",
                        column: x => x.CacadorCriadorId,
                        principalTable: "TB_Cacadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Cacadas_TB_SeresSobrenaturais_SerSobrenaturalId",
                        column: x => x.SerSobrenaturalId,
                        principalTable: "TB_SeresSobrenaturais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cacadas_CacadorCriadorId",
                table: "TB_Cacadas",
                column: "CacadorCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cacadas_SerSobrenaturalId",
                table: "TB_Cacadas",
                column: "SerSobrenaturalId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cacadores_NomeCacador",
                table: "TB_Cacadores",
                column: "NomeCacador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_SeresSobrenaturais_CacadorCriadorId",
                table: "TB_SeresSobrenaturais",
                column: "CacadorCriadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Cacadas");

            migrationBuilder.DropTable(
                name: "TB_SeresSobrenaturais");

            migrationBuilder.DropTable(
                name: "TB_Cacadores");
        }
    }
}
