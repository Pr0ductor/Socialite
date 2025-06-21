using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNotifyPropertiesToBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SharedPhoto",
                table: "Notify",
                type: "boolean USING (\"SharedPhoto\" = 0)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SendRequest",
                table: "Notify",
                type: "boolean USING (\"SendRequest\" = 0)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SendMessage",
                table: "Notify",
                type: "boolean USING (\"SendMessage\" = 0)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Mentioned",
                table: "Notify",
                type: "boolean USING (\"Mentioned\" = 0)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LikedPhoto",
                table: "Notify",
                type: "boolean USING (\"LikedPhoto\" = 0)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Followed",
                table: "Notify",
                type: "boolean USING (\"Followed\" = 0)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Notify",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Followed", "LikedPhoto", "Mentioned", "SendMessage", "SendRequest", "SharedPhoto" },
                values: new object[] { true, false, false, true, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SharedPhoto",
                table: "Notify",
                type: "integer USING CASE WHEN \"SharedPhoto\" THEN 0 ELSE 1 END",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "SendRequest",
                table: "Notify",
                type: "integer USING CASE WHEN \"SendRequest\" THEN 0 ELSE 1 END",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "SendMessage",
                table: "Notify",
                type: "integer USING CASE WHEN \"SendMessage\" THEN 0 ELSE 1 END",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Mentioned",
                table: "Notify",
                type: "integer USING CASE WHEN \"Mentioned\" THEN 0 ELSE 1 END",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "LikedPhoto",
                table: "Notify",
                type: "integer USING CASE WHEN \"LikedPhoto\" THEN 0 ELSE 1 END",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Followed",
                table: "Notify",
                type: "integer USING CASE WHEN \"Followed\" THEN 0 ELSE 1 END",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.UpdateData(
                table: "Notify",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Followed", "LikedPhoto", "Mentioned", "SendMessage", "SendRequest", "SharedPhoto" },
                values: new object[] { 0, 1, 1, 0, 1, 1 });
        }
    }
}
