using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TutoApiformation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainFormation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Tag = table.Column<string>(type: "text", nullable: true),
                    CategorieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formation_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IdIndexCategorie",
                table: "Categorie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IdIndexFormation",
                table: "Formation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_CategorieId",
                table: "Formation",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "TagIndexFormation",
                table: "Formation",
                column: "Tag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropIndex(
                name: "IdIndexCategorie",
                table: "Categorie");
        }
    }
}
