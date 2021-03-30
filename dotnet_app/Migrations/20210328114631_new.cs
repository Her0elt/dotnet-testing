using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commands",
                table: "Commands");

            migrationBuilder.RenameTable(
                name: "Commands",
                newName: "CommandsContext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandsContext",
                table: "CommandsContext",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandsContext",
                table: "CommandsContext");

            migrationBuilder.RenameTable(
                name: "CommandsContext",
                newName: "Commands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commands",
                table: "Commands",
                column: "id");
        }
    }
}
