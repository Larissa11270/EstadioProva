using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopaHAS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_JOGADORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NumeroCamisa = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    SelecaoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGADORES", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_JOGADORES",
                columns: new[] { "Id", "Nome", "NumeroCamisa", "Posicao", "SelecaoId", "Status" },
                values: new object[,]
                {
                    { 1, "Hugo Souza", 1, "Goleiro", 0, 1 },
                    { 2, "Yuri Alberto", 9, "Atacante", 0, 1 },
                    { 3, "Danilo", 2, "Lateral Direito", 0, 1 },
                    { 4, "Marquinhos", 4, "Zagueiro", 0, 1 },
                    { 5, "Casemiro", 5, "Volante", 0, 1 },
                    { 6, "Alex Sandro", 6, "Lateral Esquerdo", 0, 1 },
                    { 7, "Lucas Paquetá", 7, "Meio Campo", 0, 1 },
                    { 8, "Bruno Guimarães", 8, "Meio Campo", 0, 2 },
                    { 9, "Richarlison", 10, "Atacante", 0, 1 },
                    { 10, "Vinicius Jr", 11, "Atacante", 0, 1 },
                    { 11, "Rodrygo", 19, "Atacante", 0, 3 },
                    { 12, "Alisson", 23, "Goleiro", 0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_JOGADORES");
        }
    }
}
