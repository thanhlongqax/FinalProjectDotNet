using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gimji.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    givenName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    familyName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    birthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    telephone = table.Column<string>(type: "text", nullable: false),
                    jobTitle = table.Column<string>(type: "text", nullable: true),
                    homeLocation = table.Column<string>(type: "text", nullable: true),
                    hasCertification = table.Column<bool>(type: "boolean", nullable: true),
                    accountId = table.Column<string>(type: "text", nullable: true),
                    accountPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    givenName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    familyName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    gender = table.Column<string>(type: "text", nullable: true),
                    birthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    telephone = table.Column<string>(type: "text", nullable: false),
                    jobTitle = table.Column<string>(type: "text", nullable: true),
                    homeLocation = table.Column<string>(type: "text", nullable: false),
                    hasCertification = table.Column<bool>(type: "boolean", nullable: true),
                    accountId = table.Column<string>(type: "text", nullable: true),
                    accountPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTable",
                columns: table => new
                {
                    tableId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tableName = table.Column<string>(type: "text", nullable: false),
                    IsOccupied = table.Column<bool>(type: "boolean", nullable: false),
                    IsReserved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTable", x => x.tableId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleName = table.Column<string>(type: "text", nullable: false),
                    startDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    salaryCurrency = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productID = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    image1 = table.Column<string>(type: "text", nullable: false),
                    image2 = table.Column<string>(type: "text", nullable: false),
                    image3 = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    nsn = table.Column<string>(type: "text", nullable: false),
                    categoryCodeValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.productID);
                    table.ForeignKey(
                        name: "FK_product_category_categoryCodeValue",
                        column: x => x.categoryCodeValue,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    reservationId = table.Column<int>(type: "integer", maxLength: 30, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reservationStatus = table.Column<string>(type: "text", nullable: false),
                    bookingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    underName = table.Column<string>(type: "text", nullable: false),
                    providerid = table.Column<int>(type: "integer", nullable: false),
                    startTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    partySize = table.Column<int>(type: "integer", nullable: false),
                    RestaurantTableTableNumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.reservationId);
                    table.ForeignKey(
                        name: "FK_reservation_RestaurantTable_RestaurantTableTableNumber",
                        column: x => x.RestaurantTableTableNumber,
                        principalTable: "RestaurantTable",
                        principalColumn: "tableId");
                    table.ForeignKey(
                        name: "FK_reservation_employee_providerid",
                        column: x => x.providerid,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roleemployee",
                columns: table => new
                {
                    Employeesid = table.Column<int>(type: "integer", nullable: false),
                    RolesnumberedPosition = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roleemployee", x => new { x.Employeesid, x.RolesnumberedPosition });
                    table.ForeignKey(
                        name: "FK_Roleemployee_employee_Employeesid",
                        column: x => x.Employeesid,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roleemployee_role_RolesnumberedPosition",
                        column: x => x.RolesnumberedPosition,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_categoryCodeValue",
                table: "product",
                column: "categoryCodeValue");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_providerid",
                table: "reservation",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_RestaurantTableTableNumber",
                table: "reservation",
                column: "RestaurantTableTableNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Roleemployee_RolesnumberedPosition",
                table: "Roleemployee",
                column: "RolesnumberedPosition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "Roleemployee");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "RestaurantTable");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
