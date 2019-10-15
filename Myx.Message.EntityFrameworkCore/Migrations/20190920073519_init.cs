using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Myx.Message.EntityFrameworkCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsRecords",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNumbers = table.Column<string>(maxLength: 15, nullable: true),
                    SignName = table.Column<string>(maxLength: 20, nullable: true),
                    TemplateCode = table.Column<string>(maxLength: 50, nullable: true),
                    TemplateParam = table.Column<string>(maxLength: 500, nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Reason = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsRecords_SendTime",
                table: "SmsRecords",
                column: "SendTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsRecords");
        }
    }
}
