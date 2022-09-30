using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasylifeAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cleanings",
                columns: table => new
                {
                    Cleaningid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleanings", x => x.Cleaningid);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Clientid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Clientid);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Componentsid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeMinuts = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Componentsid);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Workerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkExperience = table.Column<double>(type: "float", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Workerid);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    RealEstateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Clientid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.RealEstateid);
                    table.ForeignKey(
                        name: "FK_RealEstates_Clients_Clientid",
                        column: x => x.Clientid,
                        principalTable: "Clients",
                        principalColumn: "Clientid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CleaningComponent",
                columns: table => new
                {
                    CleaningsCleaningid = table.Column<int>(type: "int", nullable: false),
                    Componentsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningComponent", x => new { x.CleaningsCleaningid, x.Componentsid });
                    table.ForeignKey(
                        name: "FK_CleaningComponent_Cleanings_CleaningsCleaningid",
                        column: x => x.CleaningsCleaningid,
                        principalTable: "Cleanings",
                        principalColumn: "Cleaningid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleaningComponent_Components_Componentsid",
                        column: x => x.Componentsid,
                        principalTable: "Components",
                        principalColumn: "Componentsid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerSkills",
                columns: table => new
                {
                    Componentsid = table.Column<int>(type: "int", nullable: false),
                    WorkersWorkerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerSkills", x => new { x.Componentsid, x.WorkersWorkerid });
                    table.ForeignKey(
                        name: "FK_WorkerSkills_Components_Componentsid",
                        column: x => x.Componentsid,
                        principalTable: "Components",
                        principalColumn: "Componentsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerSkills_Workers_WorkersWorkerid",
                        column: x => x.WorkersWorkerid,
                        principalTable: "Workers",
                        principalColumn: "Workerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TimeStart = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    TotalTime = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    RealEstateid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Orderid);
                    table.ForeignKey(
                        name: "FK_Orders_RealEstates_RealEstateid",
                        column: x => x.RealEstateid,
                        principalTable: "RealEstates",
                        principalColumn: "RealEstateid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentOrder",
                columns: table => new
                {
                    Componentsid = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentOrder", x => new { x.Componentsid, x.OrdersOrderid });
                    table.ForeignKey(
                        name: "FK_ComponentOrder_Components_Componentsid",
                        column: x => x.Componentsid,
                        principalTable: "Components",
                        principalColumn: "Componentsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentOrder_Orders_OrdersOrderid",
                        column: x => x.OrdersOrderid,
                        principalTable: "Orders",
                        principalColumn: "Orderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerOrder",
                columns: table => new
                {
                    OrdersOrderid = table.Column<int>(type: "int", nullable: false),
                    WorkersWorkerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerOrder", x => new { x.OrdersOrderid, x.WorkersWorkerid });
                    table.ForeignKey(
                        name: "FK_WorkerOrder_Orders_OrdersOrderid",
                        column: x => x.OrdersOrderid,
                        principalTable: "Orders",
                        principalColumn: "Orderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerOrder_Workers_WorkersWorkerid",
                        column: x => x.WorkersWorkerid,
                        principalTable: "Workers",
                        principalColumn: "Workerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningComponent_Componentsid",
                table: "CleaningComponent",
                column: "Componentsid");

            migrationBuilder.CreateIndex(
                name: "UQ__Service__737584F69C077536",
                table: "Cleanings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentOrder_OrdersOrderid",
                table: "ComponentOrder",
                column: "OrdersOrderid");

            migrationBuilder.CreateIndex(
                name: "UQ__ServiceC__737584F6AA6BDFC9",
                table: "Components",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RealEstateid",
                table: "Orders",
                column: "RealEstateid");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_Clientid",
                table: "RealEstates",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOrder_WorkersWorkerid",
                table: "WorkerOrder",
                column: "WorkersWorkerid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerSkills_WorkersWorkerid",
                table: "WorkerSkills",
                column: "WorkersWorkerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningComponent");

            migrationBuilder.DropTable(
                name: "ComponentOrder");

            migrationBuilder.DropTable(
                name: "WorkerOrder");

            migrationBuilder.DropTable(
                name: "WorkerSkills");

            migrationBuilder.DropTable(
                name: "Cleanings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
