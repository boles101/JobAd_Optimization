using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_Developer_Intern_API_Coding_Assessment.Migrations
{
    public partial class jobRequestTable_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobRequests_platformInfos_PlatformInfoId",
                        column: x => x.PlatformInfoId,
                        principalTable: "platformInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobRequests_PlatformInfoId",
                table: "jobRequests",
                column: "PlatformInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobRequests");
        }
    }
}
