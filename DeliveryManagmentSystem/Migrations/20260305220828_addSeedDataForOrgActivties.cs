using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataForOrgActivties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeliveryFeesCalculationByType",
                table: "DeliveryCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "OrganizationActivities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Delivery Client Org" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganizationActivities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryFeesCalculationByType",
                table: "DeliveryCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
