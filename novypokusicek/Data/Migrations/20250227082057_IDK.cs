using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace novypokusicek.Data.Migrations
{
    /// <inheritdoc />
    public partial class IDK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Denik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokVydani = table.Column<int>(type: "int", nullable: false),
                    Nakladatelstvi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PocetStran = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denik", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denik");
        }
    }
}
