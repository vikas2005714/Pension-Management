using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionerDetailMicroservice.Migrations
{
    public partial class addPensionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pensiondetail",
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
                    table.PrimaryKey("PK_pensiondetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pensiondetail");
        }
    }
}
