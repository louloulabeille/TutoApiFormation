using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TutoApiformation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoRessource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RessourcesId",
                table: "Formation",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ressource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lien = table.Column<string>(type: "text", nullable: false),
                    FormationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ressource_Formation_FormationId",
                        column: x => x.FormationId,
                        principalTable: "Formation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    UrlVideo = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    FormationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Formation_FormationId",
                        column: x => x.FormationId,
                        principalTable: "Formation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_FormationId",
                table: "Ressource",
                column: "FormationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_FormationId",
                table: "Video",
                column: "FormationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ressource");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropColumn(
                name: "RessourcesId",
                table: "Formation");
        }
    }
}
