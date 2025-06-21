using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamedSocialLinkProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Youtube",
                table: "SocialLinks",
                newName: "YouTube");

            migrationBuilder.RenameColumn(
                name: "Github",
                table: "SocialLinks",
                newName: "GitHub");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YouTube",
                table: "SocialLinks",
                newName: "Youtube");

            migrationBuilder.RenameColumn(
                name: "GitHub",
                table: "SocialLinks",
                newName: "Github");
        }
    }
}
