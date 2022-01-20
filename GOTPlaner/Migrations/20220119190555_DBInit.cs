using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GOTPlaner.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BadgeTypes",
                columns: table => new
                {
                    BadgeTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgeTypes", x => x.BadgeTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElementTypes",
                columns: table => new
                {
                    ElementTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.ElementTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Disability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IDCard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Email);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MountainGroups",
                columns: table => new
                {
                    MountainGroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainGroups", x => x.MountainGroupId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MountainRanges",
                columns: table => new
                {
                    MountainRangeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainRanges", x => x.MountainRangeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Disability = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.Email);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TourVerificationStatuses",
                columns: table => new
                {
                    TourVerificationStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourVerificationStatuses", x => x.TourVerificationStatusId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeaderPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LeaderEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MountainGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderPermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaderPermissions_Leaders_LeaderEmail",
                        column: x => x.LeaderEmail,
                        principalTable: "Leaders",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaderPermissions_MountainGroups_MountainGroupId",
                        column: x => x.MountainGroupId,
                        principalTable: "MountainGroups",
                        principalColumn: "MountainGroupId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TouristPoints",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MountainRangeId = table.Column<int>(type: "int", nullable: false),
                    ElementTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristPoints", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TouristPoints_ElementTypes_ElementTypeId",
                        column: x => x.ElementTypeId,
                        principalTable: "ElementTypes",
                        principalColumn: "ElementTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristPoints_MountainRanges_MountainRangeId",
                        column: x => x.MountainRangeId,
                        principalTable: "MountainRanges",
                        principalColumn: "MountainRangeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BadgeTypeId = table.Column<int>(type: "int", nullable: false),
                    TouristEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReceivalDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Badges_BadgeTypes_BadgeTypeId",
                        column: x => x.BadgeTypeId,
                        principalTable: "BadgeTypes",
                        principalColumn: "BadgeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Badges_Tourists_TouristEmail",
                        column: x => x.TouristEmail,
                        principalTable: "Tourists",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TouristEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BadgeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tours_BadgeTypes_BadgeTypeId",
                        column: x => x.BadgeTypeId,
                        principalTable: "BadgeTypes",
                        principalColumn: "BadgeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Tourists_TouristEmail",
                        column: x => x.TouristEmail,
                        principalTable: "Tourists",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TouristPointAId = table.Column<int>(type: "int", nullable: false),
                    TouristPointBId = table.Column<int>(type: "int", nullable: false),
                    PointsAB = table.Column<int>(type: "int", nullable: false),
                    PointsBA = table.Column<int>(type: "int", nullable: true),
                    LevelDifferenceSum = table.Column<int>(type: "int", nullable: false),
                    NumberOfKilometers = table.Column<double>(type: "double", nullable: false),
                    ElementTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Segments_ElementTypes_ElementTypeId",
                        column: x => x.ElementTypeId,
                        principalTable: "ElementTypes",
                        principalColumn: "ElementTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Segments_TouristPoints_TouristPointAId",
                        column: x => x.TouristPointAId,
                        principalTable: "TouristPoints",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Segments_TouristPoints_TouristPointBId",
                        column: x => x.TouristPointBId,
                        principalTable: "TouristPoints",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TourVerifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    LeaderEmail = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TourVerificationStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourVerifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourVerifications_Leaders_LeaderEmail",
                        column: x => x.LeaderEmail,
                        principalTable: "Leaders",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourVerifications_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourVerifications_TourVerificationStatuses_TourVerificationS~",
                        column: x => x.TourVerificationStatusId,
                        principalTable: "TourVerificationStatuses",
                        principalColumn: "TourVerificationStatusId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CloseSegments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SegmentID = table.Column<int>(type: "int", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseSegments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CloseSegments_Segments_SegmentID",
                        column: x => x.SegmentID,
                        principalTable: "Segments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SegmentCrosses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    SegmentId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CrossDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ImageName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentCrosses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SegmentCrosses_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SegmentCrosses_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BadgeTypes",
                columns: new[] { "BadgeTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Popularna" },
                    { 2, "MalaBrazowa" },
                    { 3, "MalaSrebrna" },
                    { 4, "MalaZlota" }
                });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "SystemType" },
                    { 2, "UserType" }
                });

            migrationBuilder.InsertData(
                table: "Leaders",
                columns: new[] { "Email", "BirthDate", "Disability", "FirstName", "IDCard", "LastName", "Password" },
                values: new object[,]
                {
                    { "leader@localhost", new DateTime(1978, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Michał", 112, "Głuś", "Leader12" },
                    { "leader2@localhost", new DateTime(1978, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kamil", 997, "Zdun", "Leader12" }
                });

            migrationBuilder.InsertData(
                table: "MountainGroups",
                columns: new[] { "MountainGroupId", "Name" },
                values: new object[,]
                {
                    { 5, "TatryIPodtatrze" },
                    { 3, "BeskidyWschodnie" },
                    { 4, "BeskidyZachodnie" },
                    { 1, "Sudety" },
                    { 2, "GorySwietokrzyskie" }
                });

            migrationBuilder.InsertData(
                table: "MountainRanges",
                columns: new[] { "MountainRangeId", "Name" },
                values: new object[,]
                {
                    { 1, "PogorzeCiechowickie" },
                    { 2, "BeskidNiskiWschod" },
                    { 3, "BeskidNiskiZachod" },
                    { 4, "Bieszczady" },
                    { 5, "PogorzeStrzyzowskoDynowskie" },
                    { 6, "PogorzePrzemyskie" }
                });

            migrationBuilder.InsertData(
                table: "TourVerificationStatuses",
                columns: new[] { "TourVerificationStatusId", "Name" },
                values: new object[,]
                {
                    { 4, "DoPonownegoRozpatrzenia" },
                    { 1, "Zgloszona" },
                    { 2, "Zaakceptowana" },
                    { 3, "Odrzucona" }
                });

            migrationBuilder.InsertData(
                table: "Tourists",
                columns: new[] { "Email", "BirthDate", "Disability", "FirstName", "LastName", "Password" },
                values: new object[] { "tourist@localhost", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Jan", "Kowalski", "Tourist1" });

            migrationBuilder.InsertData(
                table: "TouristPoints",
                columns: new[] { "ID", "ElementTypeId", "MountainRangeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 4, "Dyszowa" },
                    { 2, 1, 4, "Prełuki" },
                    { 3, 1, 4, "Mików" },
                    { 4, 1, 4, "Jaworne" },
                    { 5, 1, 4, "Rabia Skała" },
                    { 6, 1, 4, "Chmiel" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "ID", "BadgeTypeId", "CreationDate", "EndDate", "StartDate", "TouristEmail" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 26, 23, 5, 54, 781, DateTimeKind.Local).AddTicks(2529), new DateTime(2021, 10, 26, 18, 18, 54, 781, DateTimeKind.Local).AddTicks(710), "tourist@localhost" });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "ID", "ElementTypeId", "LevelDifferenceSum", "NumberOfKilometers", "PointsAB", "PointsBA", "TouristPointAId", "TouristPointBId" },
                values: new object[,]
                {
                    { 1, 1, 435, 4.0999999999999996, 7, 8, 1, 2 },
                    { 2, 1, 212, 2.3999999999999999, 5, null, 2, 3 },
                    { 3, 1, 56, 3.1000000000000001, 5, 4, 3, 4 },
                    { 4, 1, 24, 1.6000000000000001, 1, 1, 4, 5 },
                    { 5, 1, 111, 6.0, 8, 8, 2, 6 },
                    { 6, 1, 256, 5.2999999999999998, 12, 11, 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "TourVerifications",
                columns: new[] { "ID", "LeaderEmail", "Reason", "TourId", "TourVerificationStatusId", "VerificationDate" },
                values: new object[] { 1, null, null, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SegmentCrosses",
                columns: new[] { "ID", "CrossDate", "Direction", "ImageName", "Order", "SegmentId", "TourId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 26, 19, 5, 54, 781, DateTimeKind.Local).AddTicks(8387), true, "preluki.jpg", 1, 1, 1 },
                    { 2, new DateTime(2021, 10, 26, 20, 17, 54, 781, DateTimeKind.Local).AddTicks(9850), true, "mikow.jpg", 2, 2, 1 },
                    { 3, new DateTime(2021, 10, 26, 21, 26, 54, 781, DateTimeKind.Local).AddTicks(9872), true, "jaworne.jpg", 3, 3, 1 },
                    { 4, new DateTime(2021, 10, 26, 23, 5, 54, 781, DateTimeKind.Local).AddTicks(9878), true, "rabia.jpg", 4, 4, 1 }
                });

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
                name: "IX_Badges_BadgeTypeId",
                table: "Badges",
                column: "BadgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_TouristEmail",
                table: "Badges",
                column: "TouristEmail");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeTypes_Name",
                table: "BadgeTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CloseSegments_SegmentID",
                table: "CloseSegments",
                column: "SegmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderPermissions_LeaderEmail",
                table: "LeaderPermissions",
                column: "LeaderEmail");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderPermissions_MountainGroupId",
                table: "LeaderPermissions",
                column: "MountainGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_IDCard",
                table: "Leaders",
                column: "IDCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainGroups_Name",
                table: "MountainGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainRanges_Name",
                table: "MountainRanges",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SegmentCrosses_SegmentId",
                table: "SegmentCrosses",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentCrosses_TourId",
                table: "SegmentCrosses",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_ElementTypeId",
                table: "Segments",
                column: "ElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_TouristPointAId_TouristPointBId",
                table: "Segments",
                columns: new[] { "TouristPointAId", "TouristPointBId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Segments_TouristPointBId",
                table: "Segments",
                column: "TouristPointBId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_ElementTypeId",
                table: "TouristPoints",
                column: "ElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_MountainRangeId",
                table: "TouristPoints",
                column: "MountainRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_Name_MountainRangeId",
                table: "TouristPoints",
                columns: new[] { "Name", "MountainRangeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_BadgeTypeId",
                table: "Tours",
                column: "BadgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TouristEmail",
                table: "Tours",
                column: "TouristEmail");

            migrationBuilder.CreateIndex(
                name: "IX_TourVerifications_LeaderEmail",
                table: "TourVerifications",
                column: "LeaderEmail");

            migrationBuilder.CreateIndex(
                name: "IX_TourVerifications_TourId",
                table: "TourVerifications",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourVerifications_TourVerificationStatusId",
                table: "TourVerifications",
                column: "TourVerificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TourVerificationStatuses_Name",
                table: "TourVerificationStatuses",
                column: "Name",
                unique: true);
        }

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
                name: "Badges");

            migrationBuilder.DropTable(
                name: "CloseSegments");

            migrationBuilder.DropTable(
                name: "LeaderPermissions");

            migrationBuilder.DropTable(
                name: "SegmentCrosses");

            migrationBuilder.DropTable(
                name: "TourVerifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MountainGroups");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "TourVerificationStatuses");

            migrationBuilder.DropTable(
                name: "TouristPoints");

            migrationBuilder.DropTable(
                name: "BadgeTypes");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "ElementTypes");

            migrationBuilder.DropTable(
                name: "MountainRanges");
        }
    }
}
