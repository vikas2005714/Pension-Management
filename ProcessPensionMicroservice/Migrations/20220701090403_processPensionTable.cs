using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessPensionMicroservice.Migrations
{
    public partial class processPensionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PensionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAN = table.Column<long>(type: "bigint", nullable: false),
                    AadharNo = table.Column<long>(type: "bigint", nullable: false),
                    Allowances = table.Column<int>(type: "int", nullable: false),
                    SalaryEarned = table.Column<int>(type: "int", nullable: false),
                    PensionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<long>(type: "bigint", nullable: false),
                    BankType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "processPensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PensionAmount = table.Column<int>(type: "int", nullable: false),
                    BankServiceCharge = table.Column<int>(type: "int", nullable: false),
                    PensionDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processPensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_processPensions_PensionDetails_PensionDetailsId",
                        column: x => x.PensionDetailsId,
                        principalTable: "PensionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_processPensions_PensionDetailsId",
                table: "processPensions",
                column: "PensionDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "processPensions");

            migrationBuilder.DropTable(
                name: "PensionDetails");
        }
    }
}
