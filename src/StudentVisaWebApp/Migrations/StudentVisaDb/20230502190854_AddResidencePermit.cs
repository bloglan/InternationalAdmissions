using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentVisaWebApp.Migrations.StudentVisaDb
{
    /// <inheritdoc />
    public partial class AddResidencePermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Visa_IssueDate",
                table: "PersonVisa",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Visa_EnterBefore",
                table: "PersonVisa",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Visa_BirthDate",
                table: "PersonVisa",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Passport_DateOfIssue",
                table: "PersonPassport",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Passport_DateOfExpiration",
                table: "PersonPassport",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Passport_DateOfBirth",
                table: "PersonPassport",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonResidencePermit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Visa_IssueDate",
                table: "PersonVisa",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Visa_EnterBefore",
                table: "PersonVisa",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Visa_BirthDate",
                table: "PersonVisa",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Passport_DateOfIssue",
                table: "PersonPassport",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Passport_DateOfExpiration",
                table: "PersonPassport",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Passport_DateOfBirth",
                table: "PersonPassport",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
