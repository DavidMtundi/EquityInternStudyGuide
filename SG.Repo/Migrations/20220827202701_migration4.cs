using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SG.Repo.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "UploadModels",
                newName: "ContentCreatorName");

            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "UploadModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contents",
                table: "UploadModels");

            migrationBuilder.RenameColumn(
                name: "ContentCreatorName",
                table: "UploadModels",
                newName: "Content");
        }
    }
}
