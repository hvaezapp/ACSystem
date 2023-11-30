using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateMl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateSh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateMl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateSh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Letter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDateMl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateSh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Letter_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Letter_LetterType_LetterTypeId",
                        column: x => x.LetterTypeId,
                        principalTable: "LetterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LetterNote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateMl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateSh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterNote_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LetterNote_Letter_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LetterReference",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterId = table.Column<long>(type: "bigint", nullable: false),
                    FromEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ToEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateMl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateSh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterReference_Employee_FromEmployeeId",
                        column: x => x.FromEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LetterReference_Employee_ToEmployeeId",
                        column: x => x.ToEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LetterReference_Letter_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LetterAttach",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterReferenceId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDateMl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateSh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterAttach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterAttach_LetterReference_LetterReferenceId",
                        column: x => x.LetterReferenceId,
                        principalTable: "LetterReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdentityCode",
                table: "Employee",
                column: "IdentityCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Letter_EmployeeId",
                table: "Letter",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Letter_LetterTypeId",
                table: "Letter",
                column: "LetterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterAttach_LetterReferenceId",
                table: "LetterAttach",
                column: "LetterReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterNote_EmployeeId",
                table: "LetterNote",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterNote_LetterId",
                table: "LetterNote",
                column: "LetterId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterReference_FromEmployeeId",
                table: "LetterReference",
                column: "FromEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterReference_LetterId",
                table: "LetterReference",
                column: "LetterId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterReference_ToEmployeeId",
                table: "LetterReference",
                column: "ToEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterAttach");

            migrationBuilder.DropTable(
                name: "LetterNote");

            migrationBuilder.DropTable(
                name: "LetterReference");

            migrationBuilder.DropTable(
                name: "Letter");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "LetterType");
        }
    }
}
