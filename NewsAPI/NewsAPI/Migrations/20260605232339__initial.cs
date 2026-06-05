using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAPI.Migrations
{
    /// <inheritdoc />
    public partial class _initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bio = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    avatar_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    twitter_handle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    badge_color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    short_description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    read_time_minutes = table.Column<int>(type: "int", nullable: false),
                    is_trending = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_featured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_breaking = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_editors_pick = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_live = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articles_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articles_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "article_stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    article_id = table.Column<int>(type: "int", nullable: false),
                    likes_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    bookmarks_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    shares_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    comments_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_article_stats_articles_article_id",
                        column: x => x.article_id,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_stats_article_id",
                table: "article_stats",
                column: "article_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_articles_author_id",
                table: "articles",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_articles_category_id",
                table: "articles",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_slug",
                table: "categories",
                column: "slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_stats");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
