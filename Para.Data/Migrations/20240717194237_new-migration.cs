using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Para.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountyCode",
                schema: "dbo",
                table: "CustomerPhone",
                newName: "CountryCode");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhone_CountyCode_Phone",
                schema: "dbo",
                table: "CustomerPhone",
                newName: "IX_CustomerPhone_CountryCode_Phone");

            migrationBuilder.RenameColumn(
                name: "MontlyIncome",
                schema: "dbo",
                table: "CustomerDetail",
                newName: "MonthlyIncome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "dbo",
                table: "CustomerPhone",
                newName: "CountyCode");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhone_CountryCode_Phone",
                schema: "dbo",
                table: "CustomerPhone",
                newName: "IX_CustomerPhone_CountyCode_Phone");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                schema: "dbo",
                table: "CustomerDetail",
                newName: "MontlyIncome");
        }
    }
}
