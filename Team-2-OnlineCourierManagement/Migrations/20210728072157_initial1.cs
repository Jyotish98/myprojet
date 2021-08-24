using Microsoft.EntityFrameworkCore.Migrations;

namespace Team_2_OnlineCourierManagement.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ConsignmentCharges",
                table: "Consignments",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ConsignmentCharges",
                table: "Consignments",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
