using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndianDresses.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvalibleStock",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    AvalibleSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvalibleStock", x => x.StockID);
                });

            migrationBuilder.CreateTable(
                name: "OurEmployee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    ShiftStart = table.Column<DateTime>(nullable: false),
                    ShiftFinish = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurEmployee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "RegularClient",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: true),
                    ClientEmail = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    ArriveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularClient", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "OnlineSale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(nullable: false),
                    StockID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineSale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OnlineSale_RegularClient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "RegularClient",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineSale_AvalibleStock_StockID",
                        column: x => x.StockID,
                        principalTable: "AvalibleStock",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineSale_ClientID",
                table: "OnlineSale",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineSale_StockID",
                table: "OnlineSale",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineSale");

            migrationBuilder.DropTable(
                name: "OurEmployee");

            migrationBuilder.DropTable(
                name: "RegularClient");

            migrationBuilder.DropTable(
                name: "AvalibleStock");
        }
    }
}
