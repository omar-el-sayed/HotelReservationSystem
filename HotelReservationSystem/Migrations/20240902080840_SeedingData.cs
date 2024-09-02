using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e99491d-30f2-49a2-87e8-792d4c79b4a7", "3d761c7b-5e4c-4011-b644-dbdfa8d0725f", "HotelStaff", "HOTELSTAFF" },
                    { "c2beb639-b2a2-488e-96f9-418aaf97465e", "3e202890-8828-4c2c-966b-d99c40c7a40a", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1e99491d-30f2-49a2-87e8-792d4c79b4a7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c2beb639-b2a2-488e-96f9-418aaf97465e");
        }
    }
}
