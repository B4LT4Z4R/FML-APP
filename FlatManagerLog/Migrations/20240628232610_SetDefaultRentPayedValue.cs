using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatManagerLog.Migrations
{
    /// <inheritdoc />
    public partial class SetDefaultRentPayedValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    migrationBuilder.AlterColumn<string>(
        name: "RentPayed",
        table: "Tenants",
        type: "nvarchar(max)",
        nullable: false,
        defaultValue: "Not Payed",
        oldClrType: typeof(string),
        oldType: "nvarchar(max)",
        oldNullable: true);

    // Update existing records with NULL values
    migrationBuilder.Sql("UPDATE Tenants SET RentPayed = 'Not Payed' WHERE RentPayed IS NULL");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
    migrationBuilder.AlterColumn<string>(
        name: "RentPayed",
        table: "Tenants",
        type: "nvarchar(max)",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(max)",
        oldNullable: false);
        }
    }
}
