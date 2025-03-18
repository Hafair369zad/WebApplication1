using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER_TB",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CUSTOMER_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    CUSTOMER_ADDRESS = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_TB", x => x.CUSTOMER_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_TB",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 255, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_TB", x => x.PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_TB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_TB",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CUSTOMER_ID = table.Column<int>(nullable: false),
                    ORDER_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_TB", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_ORDER_TB_CUSTOMER_TB_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER_TB",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAIL_TB",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAIL_TB", x => new { x.ORDER_ID, x.PRODUCT_ID });
                    table.ForeignKey(
                        name: "FK_ORDERDETAIL_TB_ORDER_TB_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDER_TB",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERDETAIL_TB_PRODUCT_TB_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT_TB",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_TB_CUSTOMER_ID",
                table: "ORDER_TB",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAIL_TB_PRODUCT_ID",
                table: "ORDERDETAIL_TB",
                column: "PRODUCT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERDETAIL_TB");

            migrationBuilder.DropTable(
                name: "USER_TB");

            migrationBuilder.DropTable(
                name: "ORDER_TB");

            migrationBuilder.DropTable(
                name: "PRODUCT_TB");

            migrationBuilder.DropTable(
                name: "CUSTOMER_TB");
        }
    }
}
