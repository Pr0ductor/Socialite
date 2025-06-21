using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialNetwork.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageAndFriendshipEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    IntrestedCount = table.Column<int>(type: "integer", nullable: false),
                    GoingCount = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<int>(type: "integer", nullable: true),
                    Web = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Notify",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SendMessage = table.Column<int>(type: "integer", nullable: true),
                    LikedPhoto = table.Column<int>(type: "integer", nullable: true),
                    SharedPhoto = table.Column<int>(type: "integer", nullable: true),
                    Followed = table.Column<int>(type: "integer", nullable: true),
                    Mentioned = table.Column<int>(type: "integer", nullable: true),
                    SendRequest = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notify", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserPageId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    LikeCount = table.Column<int>(type: "integer", nullable: false),
                    DislikeCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privacy",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FollowMe = table.Column<int>(type: "integer", nullable: true),
                    MessageMe = table.Column<int>(type: "integer", nullable: true),
                    Activities = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    MyTags = table.Column<int>(type: "integer", nullable: true),
                    SearchEngine = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privacy", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Facebook = table.Column<string>(type: "text", nullable: true),
                    Instagram = table.Column<string>(type: "text", nullable: true),
                    Twitter = table.Column<string>(type: "text", nullable: true),
                    Youtube = table.Column<string>(type: "text", nullable: true),
                    Github = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Relationship = table.Column<int>(type: "integer", nullable: false),
                    TwoFactorAuthentication = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    FriendshipId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FriendId = table.Column<string>(type: "text", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.FriendshipId);
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_FriendId",
                        column: x => x.FriendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    SenderId = table.Column<string>(type: "text", nullable: false),
                    ReceiverId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "Content", "CreatedBy", "CreatedDate", "Id", "Img", "Name", "PostId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Очень жду данное мероприятие", null, null, 0, "/images/avatars/avatar-7.jpg", "Denis", 1, null, null },
                    { 2, "Будет здорово!", null, null, 0, "/images/avatars/avatar-1.jpg", "Anna", 1, null, null },
                    { 3, "С нетерпением жду!", null, null, 0, "/images/avatars/avatar-2.jpg", "Ivan", 1, null, null },
                    { 4, "Отличная идея!", null, null, 0, "/images/avatars/avatar-3.jpg", "Olga", 2, null, null },
                    { 5, "Не могу дождаться!", null, null, 0, "/images/avatars/avatar-4.jpg", "Sergey", 2, null, null },
                    { 6, "Будет интересно!", null, null, 0, "/images/avatars/avatar-5.jpg", "Maria", 2, null, null },
                    { 7, "Обязательно приду!", null, null, 0, "/images/avatars/avatar-6.jpg", "Alex", 2, null, null },
                    { 8, "Супер идея!", null, null, 0, "/images/avatars/avatar-7.jpg", "Elena", 2, null, null },
                    { 9, "Очень интересно!", null, null, 0, "/images/avatars/avatar-1.jpg", "Dmitry", 2, null, null },
                    { 10, "Не пропущу!", null, null, 0, "/images/avatars/avatar-2.jpg", "Kate", 2, null, null },
                    { 11, "Отличное мероприятие!", null, null, 0, "/images/avatars/avatar-3.jpg", "Victor", 3, null, null },
                    { 12, "Будет весело!", null, null, 0, "/images/avatars/avatar-4.jpg", "Svetlana", 3, null, null },
                    { 13, "С нетерпением жду!", null, null, 0, "/images/avatars/avatar-5.jpg", "Igor", 3, null, null },
                    { 14, "Отличная идея!", null, null, 0, "/images/avatars/avatar-6.jpg", "Natalia", 3, null, null },
                    { 15, "Не могу дождаться!", null, null, 0, "/images/avatars/avatar-7.jpg", "Andrey", 3, null, null },
                    { 16, "Будет интересно!", null, null, 0, "/images/avatars/avatar-1.jpg", "Yulia", 3, null, null },
                    { 17, "Обязательно приду!", null, null, 0, "/images/avatars/avatar-2.jpg", "Boris", 3, null, null },
                    { 18, "Супер идея!", null, null, 0, "/images/avatars/avatar-3.jpg", "Tatyana", 3, null, null },
                    { 19, "Очень интересно!", null, null, 0, "/images/avatars/avatar-4.jpg", "Roman", 3, null, null },
                    { 20, "Не пропущу!", null, null, 0, "/images/avatars/avatar-5.jpg", "Irina", 4, null, null },
                    { 21, "Отличное мероприятие!", null, null, 0, "/images/avatars/avatar-6.jpg", "Maxim", 4, null, null },
                    { 22, "Будет весело!", null, null, 0, "/images/avatars/avatar-7.jpg", "Lena", 4, null, null },
                    { 23, "С нетерпением жду!", null, null, 0, "/images/avatars/avatar-1.jpg", "Pavel", 4, null, null },
                    { 24, "Отличная идея!", null, null, 0, "/images/avatars/avatar-2.jpg", "Valeria", 4, null, null },
                    { 25, "Не могу дождаться!", null, null, 0, "/images/avatars/avatar-3.jpg", "Nikolay", 4, null, null },
                    { 26, "Будет интересно!", null, null, 0, "/images/avatars/avatar-4.jpg", "Ekaterina", 4, null, null },
                    { 27, "Обязательно приду!", null, null, 0, "/images/avatars/avatar-5.jpg", "Vladimir", 4, null, null },
                    { 28, "Супер идея!", null, null, 0, "/images/avatars/avatar-6.jpg", "Alina", 4, null, null },
                    { 29, "Очень интересно!", null, null, 0, "/images/avatars/avatar-7.jpg", "Grigory", 4, null, null },
                    { 30, "Не пропущу!", null, null, 0, "/images/avatars/avatar-1.jpg", "Polina", 4, null, null },
                    { 31, "Отличное мероприятие!", null, null, 0, "/images/avatars/avatar-2.jpg", "Evgeny", 4, null, null },
                    { 32, "Будет весело!", null, null, 0, "/images/avatars/avatar-3.jpg", "Ksenia", 4, null, null },
                    { 33, "С нетерпением жду!", null, null, 0, "/images/avatars/avatar-4.jpg", "Anton", 5, null, null },
                    { 34, "Отличная идея!", null, null, 0, "/images/avatars/avatar-5.jpg", "Ludmila", 5, null, null },
                    { 35, "Не могу дождаться!", null, null, 0, "/images/avatars/avatar-6.jpg", "Kirill", 5, null, null },
                    { 36, "Будет интересно!", null, null, 0, "/images/avatars/avatar-7.jpg", "Marina", 5, null, null },
                    { 37, "Обязательно приду!", null, null, 0, "/images/avatars/avatar-1.jpg", "Gleb", 5, null, null },
                    { 38, "Супер идея!", null, null, 0, "/images/avatars/avatar-2.jpg", "Vera", 5, null, null },
                    { 39, "Очень интересно!", null, null, 0, "/images/avatars/avatar-3.jpg", "Yuri", 5, null, null },
                    { 40, "Не пропущу!", null, null, 0, "/images/avatars/avatar-4.jpg", "Sofia", 5, null, null },
                    { 41, "Отличное мероприятие!", null, null, 0, "/images/avatars/avatar-5.jpg", "Ilya", 5, null, null },
                    { 42, "Будет весело!", null, null, 0, "/images/avatars/avatar-6.jpg", "Anastasia", 5, null, null },
                    { 43, "С нетерпением жду!", null, null, 0, "/images/avatars/avatar-7.jpg", "Vasily", 5, null, null },
                    { 44, "Отличная идея!", null, null, 0, "/images/avatars/avatar-1.jpg", "Alisa", 5, null, null },
                    { 45, "Не могу дождаться!", null, null, 0, "/images/avatars/avatar-2.jpg", "Fedor", 5, null, null },
                    { 46, "Будет интересно!", null, null, 0, "/images/avatars/avatar-3.jpg", "Daria", 5, null, null },
                    { 47, "Обязательно приду!", null, null, 0, "/images/avatars/avatar-4.jpg", "Mikhail", 5, null, null },
                    { 48, "Супер идея!", null, null, 0, "/images/avatars/avatar-5.jpg", "Viktoria", 5, null, null },
                    { 49, "Очень интересно!", null, null, 0, "/images/avatars/avatar-6.jpg", "Timur", 5, null, null },
                    { 50, "Не пропущу!", null, null, 0, "/images/avatars/avatar-7.jpg", "Olesya", 5, null, null },
                    { 51, "Отличное мероприятие!", null, null, 0, "/images/avatars/avatar-1.jpg", "Stanislav", 5, null, null },
                    { 52, "Будет весело!", null, null, 0, "/images/avatars/avatar-2.jpg", "Milana", 5, null, null },
                    { 53, "С нетерпением жду!", null, null, 0, "/images/avatars/avatar-3.jpg", "Artem", 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Author", "CreatedBy", "CreatedDate", "Date", "GoingCount", "Id", "Img", "IntrestedCount", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "UK BRANDS", null, null, new DateOnly(2025, 5, 1), 951, 0, "/images/events/img-1.jpg", 742, "The Global Creative", null, null },
                    { 2, "Catiana", null, null, new DateOnly(2025, 7, 15), 452, 0, "/images/events/img-2.jpg", 153, "Wedding trend Ideas", null, null },
                    { 3, "Morleam", null, null, new DateOnly(2025, 6, 24), 753, 0, "/images/events/img-3.jpg", 651, "About Safety and Flight", null, null },
                    { 4, "UK BRANDS", null, null, new DateOnly(2025, 8, 4), 614, 0, "/images/events/img-4.jpg", 824, "Perspective is everything", null, null },
                    { 5, "Global Hub", null, null, new DateOnly(2025, 3, 1), 567, 0, "/images/events/img-1.jpg", 345, "Creative Minds Meetup", null, null },
                    { 6, "TechWorld", null, null, new DateOnly(2025, 5, 1), 456, 0, "/images/events/img-2.jpg", 234, "Tech Innovators Summit", null, null },
                    { 7, "ArtLovers", null, null, new DateOnly(2025, 5, 11), 678, 0, "/images/events/img-3.jpg", 456, "Art Gallery Opening", null, null },
                    { 8, "MelodyMakers", null, null, new DateOnly(2025, 5, 3), 789, 0, "/images/events/img-4.jpg", 567, "Music Festival Night", null, null },
                    { 9, "Entrepreneurs", null, null, new DateOnly(2025, 5, 21), 890, 0, "/images/events/img-1.jpg", 678, "Startup Pitch Day", null, null },
                    { 10, "LensCrafters", null, null, new DateOnly(2025, 5, 4), 901, 0, "/images/events/img-2.jpg", 789, "Photography Workshop", null, null },
                    { 11, "FoodFanatics", null, null, new DateOnly(2025, 5, 22), 101, 0, "/images/events/img-3.jpg", 890, "Foodies Gathering", null, null },
                    { 12, "ReadersUnite", null, null, new DateOnly(2025, 6, 12), 112, 0, "/images/events/img-4.jpg", 901, "Book Club Meeting", null, null },
                    { 13, "FitLife", null, null, new DateOnly(2025, 2, 4), 223, 0, "/images/events/img-1.jpg", 101, "Fitness Bootcamp", null, null },
                    { 14, "ZenMasters", null, null, new DateOnly(2025, 5, 7), 334, 0, "/images/events/img-2.jpg", 223, "Yoga and Meditation", null, null },
                    { 15, "CodeNinjas", null, null, new DateOnly(2025, 5, 13), 445, 0, "/images/events/img-3.jpg", 334, "Coding Hackathon", null, null },
                    { 16, "GameOn", null, null, new DateOnly(2025, 5, 5), 556, 0, "/images/events/img-4.jpg", 445, "Gaming Tournament", null, null },
                    { 17, "Cinephiles", null, null, new DateOnly(2025, 4, 1), 667, 0, "/images/events/img-1.jpg", 556, "Film Screening Night", null, null },
                    { 18, "DanceLovers", null, null, new DateOnly(2025, 5, 1), 778, 0, "/images/events/img-2.jpg", 667, "Dance Workshop", null, null },
                    { 19, "StyleIcons", null, null, new DateOnly(2025, 5, 1), 889, 0, "/images/events/img-3.jpg", 778, "Fashion Show Extravaganza", null, null },
                    { 20, "Connectors", null, null, new DateOnly(2025, 5, 2), 990, 0, "/images/events/img-4.jpg", 889, "Networking Mixer", null, null },
                    { 21, "ScienceGeeks", null, null, new DateOnly(2025, 4, 30), 111, 0, "/images/events/img-1.jpg", 990, "Science Fair", null, null },
                    { 22, "KindHearts", null, null, new DateOnly(2025, 4, 30), 222, 0, "/images/events/img-2.jpg", 111, "Charity Gala Dinner", null, null },
                    { 23, "PawsAndClaws", null, null, new DateOnly(2025, 4, 30), 333, 0, "/images/events/img-3.jpg", 222, "Pet Adoption Day", null, null },
                    { 24, "NatureExplorers", null, null, new DateOnly(2025, 4, 30), 444, 0, "/images/events/img-4.jpg", 333, "Outdoor Adventure", null, null },
                    { 25, "KitchenExperts", null, null, new DateOnly(2025, 5, 2), 555, 0, "/images/events/img-1.jpg", 444, "Cooking Masterclass", null, null },
                    { 26, "CraftyHands", null, null, new DateOnly(2025, 5, 12), 666, 0, "/images/events/img-2.jpg", 555, "DIY Craft Workshop", null, null },
                    { 27, "Polyglots", null, null, new DateOnly(2025, 5, 10), 777, 0, "/images/events/img-3.jpg", 666, "Language Exchange Meetup", null, null },
                    { 28, "GameNight", null, null, new DateOnly(2025, 5, 1), 888, 0, "/images/events/img-4.jpg", 777, "Board Games Night", null, null },
                    { 29, "VRWorld", null, null, new DateOnly(2025, 5, 14), 999, 0, "/images/events/img-1.jpg", 888, "Virtual Reality Experience", null, null },
                    { 30, "LaughOutLoud", null, null, new DateOnly(2025, 5, 13), 1010, 0, "/images/events/img-2.jpg", 999, "Comedy Night Live", null, null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "Email", "Id", "Phone", "UpdatedBy", "UpdatedDate", "Web" },
                values: new object[] { 1, null, null, 0, 0, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Notify",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "Followed", "Id", "LikedPhoto", "Mentioned", "SendMessage", "SendRequest", "SharedPhoto", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, null, 0, 0, 1, 1, 0, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DislikeCount", "LikeCount", "UpdatedBy", "UpdatedDate", "UserPageId" },
                values: new object[,]
                {
                    { 1, "Контент1", null, null, 1, 1, null, null, 1 },
                    { 2, "Контент2", null, null, 3, 3, null, null, 1 },
                    { 3, "Контент3", null, null, 2, 2, null, null, 1 },
                    { 4, "Контент4", null, null, 4, 4, null, null, 1 },
                    { 5, "Контент5", null, null, 5, 5, null, null, 1 },
                    { 6, "Контент2", null, null, 2, 2, null, null, 2 },
                    { 7, "Контент3", null, null, 3, 3, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Privacy",
                columns: new[] { "UserId", "Activities", "CreatedBy", "CreatedDate", "FollowMe", "Id", "MessageMe", "MyTags", "SearchEngine", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, null, null, 0, 0, 0, 2, 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "Facebook", "Github", "Id", "Instagram", "Twitter", "UpdatedBy", "UpdatedDate", "Youtube" },
                values: new object[] { 1, null, null, "facebook", "github", 0, "instagram", "twitter", null, null, "youtube" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserId",
                table: "Friendships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Notify");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Privacy");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
