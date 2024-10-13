using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseTool.Migrations.PersonIdentityDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Locale = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExternalLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExternalLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserExternalLogin_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "varchar(50)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserInRole_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ApplicationUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ApplicationUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExternalLogin_UserId",
                table: "UserExternalLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRole_RoleId",
                table: "UserInRole",
                column: "RoleId");

            migrationBuilder.Sql(File.ReadAllText("Migrations/PersonIdentityDb/202410132327.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserExternalLogin");

            migrationBuilder.DropTable(
                name: "UserInRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
