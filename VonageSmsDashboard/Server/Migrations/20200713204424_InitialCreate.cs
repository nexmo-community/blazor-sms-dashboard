using Microsoft.EntityFrameworkCore.Migrations;

namespace VonageSmsDashboard.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dlrs",
                columns: table => new
                {
                    MessageId = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    MessageTimestamp = table.Column<string>(nullable: true),
                    Msisdn = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlrs", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "InboundSms",
                columns: table => new
                {
                    MessageId = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    MessageTimestamp = table.Column<string>(nullable: true),
                    Msisdn = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundSms", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "OutboundSms",
                columns: table => new
                {
                    MessageId = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    MessagePrice = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundSms", x => x.MessageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dlrs");

            migrationBuilder.DropTable(
                name: "InboundSms");

            migrationBuilder.DropTable(
                name: "OutboundSms");
        }
    }
}
