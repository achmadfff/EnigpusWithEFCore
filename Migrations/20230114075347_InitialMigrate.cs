using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnigpusEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "m_magazine",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    title = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    publishingperiod = table.Column<string>(name: "publishing_period", type: "Nvarchar(50)", nullable: false),
                    publicationyear = table.Column<int>(name: "publication_year", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_magazine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_novel",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "Nvarchar(25)", nullable: false),
                    title = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    publisher = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    publicationyear = table.Column<int>(name: "publication_year", type: "int", nullable: false),
                    author = table.Column<string>(type: "Nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_novel", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_magazine_code",
                schema: "dbo",
                table: "m_magazine",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_m_novel_code",
                schema: "dbo",
                table: "m_novel",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_magazine",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_novel",
                schema: "dbo");
        }
    }
}
