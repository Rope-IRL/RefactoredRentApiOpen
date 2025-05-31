using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestfulApiTry.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeignKeyInFlatsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Landlords_LandlordModelId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_LandlordModelId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "LandlordModelId",
                table: "Flats");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_LandlordId",
                table: "Flats",
                column: "LandlordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Landlords_LandlordId",
                table: "Flats",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Landlords_LandlordId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_LandlordId",
                table: "Flats");

            migrationBuilder.AddColumn<int>(
                name: "LandlordModelId",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_LandlordModelId",
                table: "Flats",
                column: "LandlordModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Landlords_LandlordModelId",
                table: "Flats",
                column: "LandlordModelId",
                principalTable: "Landlords",
                principalColumn: "Id");
        }
    }
}
