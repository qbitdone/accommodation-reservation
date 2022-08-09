using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staycation.Api.Migrations
{
    public partial class LocationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Accommodations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_LocationId",
                table: "Accommodations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Location_LocationId",
                table: "Accommodations",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Location_LocationId",
                table: "Accommodations");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_LocationId",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Accommodations");
        }
    }
}
