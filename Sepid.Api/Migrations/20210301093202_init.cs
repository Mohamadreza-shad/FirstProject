using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sepid.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseResponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SwResult = table.Column<int>(nullable: false),
                    Rrn = table.Column<long>(nullable: false),
                    Issrrn = table.Column<long>(nullable: false),
                    Stan = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    MessageCode = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FaMessageDesc = table.Column<string>(nullable: true),
                    EnMessageDesc = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    CentralMessageCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Counter = table.Column<long>(nullable: false),
                    LockFlag = table.Column<int>(nullable: false),
                    AmountAfterDiscount = table.Column<long>(nullable: false),
                    AmountBeforeDiscount = table.Column<long>(nullable: false),
                    CampaignID = table.Column<int>(nullable: false),
                    TerminalID = table.Column<int>(nullable: false),
                    InstituteId = table.Column<int>(nullable: false),
                    PAN = table.Column<long>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    BarcodeStan = table.Column<int>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    ReceiveDate = table.Column<DateTime>(nullable: false),
                    WalletId = table.Column<int>(nullable: true),
                    EntityId = table.Column<long>(nullable: true),
                    IpgrRn = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PurchaseResponseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequest_PurchaseResponse_PurchaseResponseId",
                        column: x => x.PurchaseResponseId,
                        principalTable: "PurchaseResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_PurchaseResponseId",
                table: "PurchaseRequest",
                column: "PurchaseResponseId",
                unique: true,
                filter: "[PurchaseResponseId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRequest");

            migrationBuilder.DropTable(
                name: "PurchaseResponse");
        }
    }
}
