using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseTool.Migrations.AdmissionDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmissionPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PublishTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    CanRequest = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionPlanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AdmissionPlan_AdmissionPlanId",
                        column: x => x.AdmissionPlanId,
                        principalTable: "AdmissionPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdmissionPlanId",
                table: "Student",
                column: "AdmissionPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AdmissionPlan");
        }
    }
}
