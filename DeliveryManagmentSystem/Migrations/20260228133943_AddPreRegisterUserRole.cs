using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPreRegisterUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a3c9e9f1-6b2d-4c5a-b8f7-1d2e3c4b5a6f"), null, "PreRegister", "PREREGISTER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3c9e9f1-6b2d-4c5a-b8f7-1d2e3c4b5a6f"));
        }
    }
}
