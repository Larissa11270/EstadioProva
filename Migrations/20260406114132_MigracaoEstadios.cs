using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopaHAS.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoEstadios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ESTADIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTADIO", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ESTADIO",
                columns: new[] { "Id", "Capacidade", "Cidade", "Nome" },
                values: new object[,]
                {
                    { 1, 50000, "Rio de Janeiro", "Maracanã" },
                    { 2, 20000, "São Paulo", "Pacaembu" },
                    { 3, 80000, "São Paulo", "Morumbi" },
                    { 4, 90000, "São Paulo", "Allianz Parque" },
                    { 5, 30000, "São Paulo", "Canindé" },
                    { 6, 100000, "São Paulo", "Neo Química Arena" },
                    { 7, 40000, "Santos", "Rua Javari" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ESTADIO");
        }
    }
}
