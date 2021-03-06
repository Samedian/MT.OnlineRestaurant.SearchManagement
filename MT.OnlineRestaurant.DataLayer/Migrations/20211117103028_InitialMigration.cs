using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoggingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('')"),
                    ControllerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, defaultValueSql: "('')"),
                    ActionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, defaultValueSql: "('')"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCuisine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuisine = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCuisine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblLocation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Y = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMenu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    tblCuisineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblMenu_tblCuisineID",
                        column: x => x.tblCuisineID,
                        principalTable: "tblCuisine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRestaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    tblLocationID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    ContactNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "('')"),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    OpeningTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValueSql: "('')"),
                    CloseTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRestaurant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblRestaurant_tblLocationID",
                        column: x => x.tblLocationID,
                        principalTable: "tblLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOffer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tblRestaurantID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    tblMenuID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Price = table.Column<decimal>(type: "decimal", nullable: false, defaultValueSql: "((0))"),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    Discount = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOffer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblOffer_tblMenuID",
                        column: x => x.tblMenuID,
                        principalTable: "tblMenu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOffer_tblRestaurantID",
                        column: x => x.tblRestaurantID,
                        principalTable: "tblRestaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValueSql: "('')"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('')"),
                    tblRestaurantID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    tblCustomerId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblRating_tblRestaurantID",
                        column: x => x.tblRestaurantID,
                        principalTable: "tblRestaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRestaurantDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tblRestaurantID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    TableCount = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    TableCapacity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserCreated = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    UserModified = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRestaurantDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblRestaurantDetails_tblRestaurantID",
                        column: x => x.tblRestaurantID,
                        principalTable: "tblRestaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__tblLocat__3BD0198414754610",
                table: "tblLocation",
                column: "X",
                unique: true,
                filter: "[X] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__tblLocat__3BD01987EC697B94",
                table: "tblLocation",
                column: "Y",
                unique: true,
                filter: "[Y] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblMenu_tblCuisineID",
                table: "tblMenu",
                column: "tblCuisineID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOffer_tblMenuID",
                table: "tblOffer",
                column: "tblMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOffer_tblRestaurantID",
                table: "tblOffer",
                column: "tblRestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRating_tblRestaurantID",
                table: "tblRating",
                column: "tblRestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRestaurant_tblLocationID",
                table: "tblRestaurant",
                column: "tblLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRestaurantDetails_tblRestaurantID",
                table: "tblRestaurantDetails",
                column: "tblRestaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoggingInfo");

            migrationBuilder.DropTable(
                name: "tblOffer");

            migrationBuilder.DropTable(
                name: "tblRating");

            migrationBuilder.DropTable(
                name: "tblRestaurantDetails");

            migrationBuilder.DropTable(
                name: "tblMenu");

            migrationBuilder.DropTable(
                name: "tblRestaurant");

            migrationBuilder.DropTable(
                name: "tblCuisine");

            migrationBuilder.DropTable(
                name: "tblLocation");
        }
    }
}
