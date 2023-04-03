using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    ShelterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CertificateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatFoodStock = table.Column<int>(type: "int", nullable: false),
                    DogFoodStock = table.Column<int>(type: "int", nullable: false),
                    RabiesVaccineStock = table.Column<int>(type: "int", nullable: false),
                    CombinationVaccineStock = table.Column<int>(type: "int", nullable: false),
                    ParvovirusVaccineStock = table.Column<int>(type: "int", nullable: false),
                    DistemperVaccineStock = table.Column<int>(type: "int", nullable: false),
                    HepatitisVaccineStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.ShelterId);
                    table.ForeignKey(
                        name: "FK_Shelters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: true),
                    BroughtToShelter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OwningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FertilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pregnancy = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                    table.ForeignKey(
                        name: "FK_Cats_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "ShelterId");
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: true),
                    BroughtToShelter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OwningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FertilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pregnancy = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dogs_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "ShelterId");
                });

            migrationBuilder.CreateTable(
                name: "CatDiseaseHistories",
                columns: table => new
                {
                    CatDiseaseHistoryId = table.Column<int>(type: "int", nullable: false),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDiseaseHistories", x => new { x.CatDiseaseHistoryId, x.CatId });
                    table.ForeignKey(
                        name: "FK_CatDiseaseHistories_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatTestings",
                columns: table => new
                {
                    CatTestingId = table.Column<int>(type: "int", nullable: false),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTestings", x => new { x.CatTestingId, x.CatId });
                    table.ForeignKey(
                        name: "FK_CatTestings_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatVaccinations",
                columns: table => new
                {
                    CatVaccinationId = table.Column<int>(type: "int", nullable: false),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinationExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatVaccinations", x => new { x.CatVaccinationId, x.CatId });
                    table.ForeignKey(
                        name: "FK_CatVaccinations_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogDiseaseHistories",
                columns: table => new
                {
                    DogDiseaseHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: true),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogDiseaseHistories", x => x.DogDiseaseHistoryId);
                    table.ForeignKey(
                        name: "FK_DogDiseaseHistories_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId");
                });

            migrationBuilder.CreateTable(
                name: "DogTestings",
                columns: table => new
                {
                    DogTestingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogTestings", x => x.DogTestingId);
                    table.ForeignKey(
                        name: "FK_DogTestings_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId");
                });

            migrationBuilder.CreateTable(
                name: "DogVaccinations",
                columns: table => new
                {
                    DogVaccinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogId = table.Column<int>(type: "int", nullable: true),
                    VaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinationExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogVaccinations", x => x.DogVaccinationId);
                    table.ForeignKey(
                        name: "FK_DogVaccinations_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatDiseaseHistories_CatId",
                table: "CatDiseaseHistories",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_ShelterId",
                table: "Cats",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_CatTestings_CatId",
                table: "CatTestings",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_CatVaccinations_CatId",
                table: "CatVaccinations",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ShelterId",
                table: "Dogs",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_DogDiseaseHistories_DogId",
                table: "DogDiseaseHistories",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogTestings_DogId",
                table: "DogTestings",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogVaccinations_DogId",
                table: "DogVaccinations",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_UserId",
                table: "Shelters",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatDiseaseHistories");

            migrationBuilder.DropTable(
                name: "CatTestings");

            migrationBuilder.DropTable(
                name: "CatVaccinations");

            migrationBuilder.DropTable(
                name: "DogDiseaseHistories");

            migrationBuilder.DropTable(
                name: "DogTestings");

            migrationBuilder.DropTable(
                name: "DogVaccinations");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
