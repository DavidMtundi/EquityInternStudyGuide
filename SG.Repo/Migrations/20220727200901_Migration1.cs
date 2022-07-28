using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SG.Repo.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentCreatorModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCreatorModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PFNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    ContentCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadModels_ContentCreatorModels_ContentCreatorId",
                        column: x => x.ContentCreatorId,
                        principalTable: "ContentCreatorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningMaterialModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningMaterialModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningMaterialModels_InternModels_InternModelId",
                        column: x => x.InternModelId,
                        principalTable: "InternModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningMaterialModels_UploadModels_UploadModelId",
                        column: x => x.UploadModelId,
                        principalTable: "UploadModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterialModels_InternModelId",
                table: "LearningMaterialModels",
                column: "InternModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterialModels_UploadModelId",
                table: "LearningMaterialModels",
                column: "UploadModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadModels_ContentCreatorId",
                table: "UploadModels",
                column: "ContentCreatorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningMaterialModels");

            migrationBuilder.DropTable(
                name: "InternModels");

            migrationBuilder.DropTable(
                name: "UploadModels");

            migrationBuilder.DropTable(
                name: "ContentCreatorModels");
        }
    }
}
