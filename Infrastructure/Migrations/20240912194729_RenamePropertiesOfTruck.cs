using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePropertiesOfTruck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicensePlate",
                table: "Trucks",
                newName: "Plate");

            migrationBuilder.RenameColumn(
                name: "ClaimedRawMaterialWeight",
                table: "Trucks",
                newName: "Weight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Trucks",
                newName: "ClaimedRawMaterialWeight");

            migrationBuilder.RenameColumn(
                name: "Plate",
                table: "Trucks",
                newName: "LicensePlate");
        }
    }
}
