using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNegozio.Migrations
{
    public partial class prodottiNegozio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornitore",
                columns: table => new
                {
                    IdFrntr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fornitor__D40587492BF31CB4", x => x.IdFrntr);
                });

            migrationBuilder.CreateTable(
                name: "Prodotto",
                columns: table => new
                {
                    IdPrdt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Categoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Giacenza = table.Column<byte>(type: "tinyint", nullable: false),
                    Descrizione = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Disponibile = table.Column<bool>(type: "bit", nullable: false),
                    ImgUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prodotto__E40DCE64BB4163F5", x => x.IdPrdt);
                });

            migrationBuilder.CreateTable(
                name: "Taglia",
                columns: table => new
                {
                    IdTaglia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagliaVestito = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Taglia__7FFB1DAD06F2ABAE", x => x.IdTaglia);
                });

            migrationBuilder.CreateTable(
                name: "TaglieFornitori",
                columns: table => new
                {
                    IdTglFr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFrntr = table.Column<int>(type: "int", nullable: false),
                    IdTaglia = table.Column<int>(type: "int", nullable: false),
                    IdPrdt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaglieFo__BCC26CBE221E0865", x => x.IdTglFr);
                    table.ForeignKey(
                        name: "FK_TaglieFornitori_Fornitore",
                        column: x => x.IdFrntr,
                        principalTable: "Fornitore",
                        principalColumn: "IdFrntr");
                    table.ForeignKey(
                        name: "FK_TaglieFornitori_Prodotto",
                        column: x => x.IdPrdt,
                        principalTable: "Prodotto",
                        principalColumn: "IdPrdt");
                    table.ForeignKey(
                        name: "FK_TaglieFornitori_Taglia",
                        column: x => x.IdTaglia,
                        principalTable: "Taglia",
                        principalColumn: "IdTaglia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaglieFornitori_IdFrntr",
                table: "TaglieFornitori",
                column: "IdFrntr");

            migrationBuilder.CreateIndex(
                name: "IX_TaglieFornitori_IdPrdt",
                table: "TaglieFornitori",
                column: "IdPrdt");

            migrationBuilder.CreateIndex(
                name: "IX_TaglieFornitori_IdTaglia",
                table: "TaglieFornitori",
                column: "IdTaglia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaglieFornitori");

            migrationBuilder.DropTable(
                name: "Fornitore");

            migrationBuilder.DropTable(
                name: "Prodotto");

            migrationBuilder.DropTable(
                name: "Taglia");
        }
    }
}
