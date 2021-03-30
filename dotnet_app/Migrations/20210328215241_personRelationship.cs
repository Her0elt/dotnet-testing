using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class personRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonContext_dadId",
                table: "PersonContext");

            migrationBuilder.DropIndex(
                name: "IX_PersonContext_momId",
                table: "PersonContext");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContext_dadId",
                table: "PersonContext",
                column: "dadId",
                unique: true,
                filter: "[dadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContext_momId",
                table: "PersonContext",
                column: "momId",
                unique: true,
                filter: "[momId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonContext_dadId",
                table: "PersonContext");

            migrationBuilder.DropIndex(
                name: "IX_PersonContext_momId",
                table: "PersonContext");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContext_dadId",
                table: "PersonContext",
                column: "dadId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContext_momId",
                table: "PersonContext",
                column: "momId");
        }
    }
}
