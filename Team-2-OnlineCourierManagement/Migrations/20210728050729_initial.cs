using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Team_2_OnlineCourierManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Consignees",
                columns: table => new
                {
                    ConsigneeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignees", x => x.ConsigneeId);
                });

            migrationBuilder.CreateTable(
                name: "Consigners",
                columns: table => new
                {
                    ConsignerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consigners", x => x.ConsignerId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryExecutives",
                columns: table => new
                {
                    DeliveryExecitiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryExecutives", x => x.DeliveryExecitiveId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Consignments",
                columns: table => new
                {
                    ConsignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsignmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBooking = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsignmentCharges = table.Column<double>(type: "float", nullable: false),
                    ConsignmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeId = table.Column<int>(type: "int", nullable: false),
                    ConsignerId = table.Column<int>(type: "int", nullable: false),
                    DeliveryExecitiveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignments", x => x.ConsignmentId);
                    table.ForeignKey(
                        name: "FK_Consignments_Consignees_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "Consignees",
                        principalColumn: "ConsigneeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consignments_Consigners_ConsignerId",
                        column: x => x.ConsignerId,
                        principalTable: "Consigners",
                        principalColumn: "ConsignerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consignments_DeliveryExecutives_DeliveryExecitiveId",
                        column: x => x.DeliveryExecitiveId,
                        principalTable: "DeliveryExecutives",
                        principalColumn: "DeliveryExecitiveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsignmentId = table.Column<int>(type: "int", nullable: true),
                    ConsignmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsigneeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsigneeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsignerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsignerContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsignerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsignmentCharges = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillNo);
                    table.ForeignKey(
                        name: "FK_Bills_Consignments_ConsignmentId",
                        column: x => x.ConsignmentId,
                        principalTable: "Consignments",
                        principalColumn: "ConsignmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ConsignmentId",
                table: "Bills",
                column: "ConsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_ConsigneeId",
                table: "Consignments",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_ConsignerId",
                table: "Consignments",
                column: "ConsignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_DeliveryExecitiveId",
                table: "Consignments",
                column: "DeliveryExecitiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Consignments");

            migrationBuilder.DropTable(
                name: "Consignees");

            migrationBuilder.DropTable(
                name: "Consigners");

            migrationBuilder.DropTable(
                name: "DeliveryExecutives");
        }
    }
}
