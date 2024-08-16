using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblM_Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblM_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblM_Hobi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblM_Hobi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblT_Umur",
                columns: table => new
                {
                    Umur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblT_Umur", x => x.Umur);
                });

            migrationBuilder.CreateTable(
                name: "tblT_Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGender = table.Column<int>(type: "int", nullable: false),
                    IdHobi = table.Column<int>(type: "int", nullable: false),
                    Umur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblT_Personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblT_Personal_tblM_Gender_IdGender",
                        column: x => x.IdGender,
                        principalTable: "tblM_Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblT_Personal_tblM_Hobi_IdHobi",
                        column: x => x.IdHobi,
                        principalTable: "tblM_Hobi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblT_Personal_IdGender",
                table: "tblT_Personal",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_tblT_Personal_IdHobi",
                table: "tblT_Personal",
                column: "IdHobi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblT_Personal");

            migrationBuilder.DropTable(
                name: "tblT_Umur");

            migrationBuilder.DropTable(
                name: "tblM_Gender");

            migrationBuilder.DropTable(
                name: "tblM_Hobi");
        }
    }
}
