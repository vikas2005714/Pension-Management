using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessPensionMicroservice.Migrations
{
    public partial class updateProcessPension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_processPensions_PensionDetails_PensionDetailsId",
                table: "processPensions");

            migrationBuilder.DropTable(
                name: "PensionDetails");

            migrationBuilder.DropIndex(
                name: "IX_processPensions_PensionDetailsId",
                table: "processPensions");

            migrationBuilder.RenameColumn(
                name: "PensionDetailsId",
                table: "processPensions",
                newName: "AddharId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddharId",
                table: "processPensions",
                newName: "PensionDetailsId");

            migrationBuilder.CreateTable(
                name: "PensionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AadharNo = table.Column<long>(type: "bigint", nullable: false),
                    AccountNo = table.Column<long>(type: "bigint", nullable: false),
                    Allowances = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAN = table.Column<long>(type: "bigint", nullable: false),
                    PensionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryEarned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensionDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_processPensions_PensionDetailsId",
                table: "processPensions",
                column: "PensionDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_processPensions_PensionDetails_PensionDetailsId",
                table: "processPensions",
                column: "PensionDetailsId",
                principalTable: "PensionDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
