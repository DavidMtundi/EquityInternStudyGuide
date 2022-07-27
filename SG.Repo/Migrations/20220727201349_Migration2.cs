using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SG.Repo.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UploadModels_ContentCreatorId",
                table: "UploadModels");

            migrationBuilder.CreateIndex(
                name: "IX_UploadModels_ContentCreatorId",
                table: "UploadModels",
                column: "ContentCreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UploadModels_ContentCreatorId",
                table: "UploadModels");

            migrationBuilder.CreateIndex(
                name: "IX_UploadModels_ContentCreatorId",
                table: "UploadModels",
                column: "ContentCreatorId",
                unique: true);
        }
    }
}
