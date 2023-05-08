using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmissionsPortalWebApp.Migrations.StudentDocumentDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonPassport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Passport_Type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Passport_CountryCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Passport_PassportNumber = table.Column<string>(type: "char(9)", nullable: false),
                    Passport_Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Passport_GivenName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Passport_Sex = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Passport_Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Passport_DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Passport_PlaceOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Passport_DateOfIssue = table.Column<DateTime>(type: "date", nullable: false),
                    Passport_DateOfExpiration = table.Column<DateTime>(type: "date", nullable: false),
                    Passport_Authority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manager_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Manager_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenChanged = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPassport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonResidencePermit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Manager_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Manager_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResidencePermit_Number = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    ResidencePermit_FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ResidencePermit_Sex = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ResidencePermit_DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    ResidencePermit_PassportNumber = table.Column<string>(type: "char(9)", nullable: false),
                    ResidencePermit_PurposeForResidence = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ResidencePermit_ValidForResidenceUntil = table.Column<DateTime>(type: "date", nullable: false),
                    ResidencePermit_DateOfIssue = table.Column<DateTime>(type: "date", nullable: false),
                    ResidencePermit_PlaceOfIssue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ResidencePermit_Observations = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenChanged = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonResidencePermit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonVisa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Visa_VisaNumber = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    Visa_Category = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Visa_Entries = table.Column<int>(type: "int", nullable: false),
                    Visa_EnterBefore = table.Column<DateTime>(type: "date", nullable: false),
                    Visa_DurationOfEachStay = table.Column<int>(type: "int", nullable: false),
                    Visa_IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    Visa_IssuedAt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Visa_FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Visa_BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Visa_PassportNumber = table.Column<string>(type: "char(9)", nullable: false),
                    Visa_Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Manager_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Manager_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenChanged = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVisa", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPassport");

            migrationBuilder.DropTable(
                name: "PersonResidencePermit");

            migrationBuilder.DropTable(
                name: "PersonVisa");
        }
    }
}
