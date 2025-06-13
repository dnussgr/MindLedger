using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindLedger.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                table: "Notes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteType",
                table: "Notes",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SessionNumber",
                table: "Notes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteBaseTag",
                columns: table => new
                {
                    NotesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteBaseTag", x => new { x.NotesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_NoteBaseTag_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteBaseTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CampaignId",
                table: "Notes",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteBaseTag_TagsId",
                table: "NoteBaseTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Campaigns_CampaignId",
                table: "Notes",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Campaigns_CampaignId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "NoteBaseTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CampaignId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "SessionNumber",
                table: "Notes");
        }
    }
}
