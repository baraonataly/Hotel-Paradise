using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelParadiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarQuartosEReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Capacidade = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "TEXT", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HospedeId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuartoNumero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Hospedes_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "Hospedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Quartos_QuartoNumero",
                        column: x => x.QuartoNumero,
                        principalTable: "Quartos",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HospedeId",
                table: "Reservas",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_QuartoNumero",
                table: "Reservas",
                column: "QuartoNumero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Quartos");
        }
    }
}
