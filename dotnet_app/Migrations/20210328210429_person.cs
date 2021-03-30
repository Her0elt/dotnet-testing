using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonContext",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    dadId = table.Column<int>(type: "int", nullable: true),
                    momId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContext", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonContext_PersonContext_dadId",
                        column: x => x.dadId,
                        principalTable: "PersonContext",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonContext_PersonContext_momId",
                        column: x => x.momId,
                        principalTable: "PersonContext",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContext_dadId",
                table: "PersonContext",
                column: "dadId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContext_momId",
                table: "PersonContext",
                column: "momId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonContext");
        }
    }
}
