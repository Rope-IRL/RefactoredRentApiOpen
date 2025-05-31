using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestfulApiTry.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppliedFlatConfigAndChangedSomeConfigsInLandlordAndLessee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandlordInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LesseeInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AverageMark = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumberOfRooms = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfFloors = table.Column<short>(type: "smallint", nullable: false),
                    IsBathRoomAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsWiFiAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(7,3)", precision: 7, scale: 3, nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    LandlordModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_Landlords_LandlordModelId",
                        column: x => x.LandlordModelId,
                        principalTable: "Landlords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LandlordInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Score = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false, defaultValue: 0m),
                    LandlordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlordInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandlordInformations_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LesseeInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Score = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false, defaultValue: 0m),
                    LesseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesseeInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LesseeInformations_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_LandlordModelId",
                table: "Flats",
                column: "LandlordModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LandlordInformations_LandlordId",
                table: "LandlordInformations",
                column: "LandlordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LesseeInformations_LesseeId",
                table: "LesseeInformations",
                column: "LesseeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "LandlordInformations");

            migrationBuilder.DropTable(
                name: "LesseeInformations");

            migrationBuilder.DropTable(
                name: "Landlords");

            migrationBuilder.DropTable(
                name: "Lessees");
        }
    }
}
