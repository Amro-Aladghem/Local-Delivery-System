using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeliveryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeliveryOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClientDeliveryOrderStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeliveryOrderStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrderStatuses_ClientDeliveryOrderStatuses_ClientDeliveryOrderStatusId",
                        column: x => x.ClientDeliveryOrderStatusId,
                        principalTable: "ClientDeliveryOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VechicalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VechicalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ReffreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReffreshTokenExpired = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryClientOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientOrgType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationActivityId = table.Column<int>(type: "int", nullable: false),
                    AvgDailyOrders = table.Column<int>(type: "int", nullable: false),
                    AvgMonthlyOrders = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DateOfRegister = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FacebookPageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstagramPageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryClientOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryClientOrganizations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryClientOrganizations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryClientOrganizations_OrganizationActivities_OrganizationActivityId",
                        column: x => x.OrganizationActivityId,
                        principalTable: "OrganizationActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryFeesCalculationByType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DateOfRegister = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FacebookPageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstagramPageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryClientOrgProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryClientOrgProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryClientOrgProducts_DeliveryClientOrganizations_DeliveryClientOrganizationId",
                        column: x => x.DeliveryClientOrganizationId,
                        principalTable: "DeliveryClientOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryClientUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastLoggedInDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    DeliveryClientOrgUserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryClientUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryClientUsers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryClientUsers_DeliveryClientOrganizations_DeliveryClientOrganizationId",
                        column: x => x.DeliveryClientOrganizationId,
                        principalTable: "DeliveryClientOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrganizationCompaniesDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrganizationCompaniesDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientOrganizationCompaniesDeliveries_DeliveryClientOrganizations_DeliveryClientOrganizationId",
                        column: x => x.DeliveryClientOrganizationId,
                        principalTable: "DeliveryClientOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientOrganizationCompaniesDeliveries_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanyCitiesPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DeliveryFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true, defaultValue: 0m),
                    AdditionalFeesName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanyCitiesPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyCitiesPrices_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyCitiesPrices_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanyDeliveryType",
                columns: table => new
                {
                    DeliveryCompaniesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanyDeliveryType", x => new { x.DeliveryCompaniesId, x.DeliveryTypesId });
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyDeliveryType_DeliveryCompanies_DeliveryCompaniesId",
                        column: x => x.DeliveryCompaniesId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyDeliveryType_DeliveryTypes_DeliveryTypesId",
                        column: x => x.DeliveryTypesId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanyDeliveryTypes",
                columns: table => new
                {
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false),
                    EstimatedDateTimeArriavle = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    AdditaionalFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanyDeliveryTypes", x => new { x.DeliveryTypeId, x.DeliveryCompanyId });
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyDeliveryTypes_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyDeliveryTypes_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanyDistancePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinDistanceKm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    MaxDistanceKm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DeliveryFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true, defaultValue: 0m),
                    AdditionalFeesName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanyDistancePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyDistancePrices_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanyUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompanyUserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoggedInDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyUsers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryCompanyUsers_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrivingLicenseImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VechicalNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VechicalTypeId = table.Column<int>(type: "int", nullable: false),
                    LastLoggedInTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_VechicalTypes_VechicalTypeId",
                        column: x => x.VechicalTypeId,
                        principalTable: "VechicalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientDeliveryOrderStatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ReceiverFirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReceiverLastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReceiverPhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReceiverSecondPhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GoogleMapUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Fragile = table.Column<bool>(type: "bit", nullable: false),
                    Flammable = table.Column<bool>(type: "bit", nullable: false),
                    RequiresRefrigeration = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    ClientNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RejectedNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrders_ClientDeliveryOrderStatuses_ClientDeliveryOrderStatusId",
                        column: x => x.ClientDeliveryOrderStatusId,
                        principalTable: "ClientDeliveryOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrders_DeliveryClientOrganizations_DeliveryClientOrganizationId",
                        column: x => x.DeliveryClientOrganizationId,
                        principalTable: "DeliveryClientOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrders_DeliveryClientUsers_DeliveryClientUserId",
                        column: x => x.DeliveryClientUserId,
                        principalTable: "DeliveryClientUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrders_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryOrders_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientRequestsToDevlieryCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryClientOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientRequestsStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    HasAcceptedYet = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RejectedNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequestsToDevlieryCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientRequestsToDevlieryCompanies_DeliveryClientOrganizations_DeliveryClientOrganizationId",
                        column: x => x.DeliveryClientOrganizationId,
                        principalTable: "DeliveryClientOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientRequestsToDevlieryCompanies_DeliveryClientUsers_DeliveryClientUserId",
                        column: x => x.DeliveryClientUserId,
                        principalTable: "DeliveryClientUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientRequestsToDevlieryCompanies_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    AcceptedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    CompletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverAssignments_DeliveryCompanyUsers_AssignedBy",
                        column: x => x.AssignedBy,
                        principalTable: "DeliveryCompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriverAssignments_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrderAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDeliveryOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FloorNumber = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderAddresses_ClientDeliveryOrders_ClientDeliveryOrderId",
                        column: x => x.ClientDeliveryOrderId,
                        principalTable: "ClientDeliveryOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientDeliveryOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerSecondPhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerAddressUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeliveryOrderAddressId = table.Column<int>(type: "int", nullable: false),
                    Fragile = table.Column<bool>(type: "bit", nullable: false),
                    Flammable = table.Column<bool>(type: "bit", nullable: false),
                    RequiresRefrigeration = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    AcceptedFromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    ClientNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderTotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DeliveryFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true, defaultValue: 0m),
                    AdditionalFeesName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AcceptedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    EstimatedDateTimeofDelevired = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    OrderSerialNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_ClientDeliveryOrders_ClientDeliveryOrderId",
                        column: x => x.ClientDeliveryOrderId,
                        principalTable: "ClientDeliveryOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryCompanyUsers_AcceptedFromUserId",
                        column: x => x.AcceptedFromUserId,
                        principalTable: "DeliveryCompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryOrderAddresses_DeliveryOrderAddressId",
                        column: x => x.DeliveryOrderAddressId,
                        principalTable: "DeliveryOrderAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryOrderStatuses_DeliveryOrderStatusId",
                        column: x => x.DeliveryOrderStatusId,
                        principalTable: "DeliveryOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3c7e9f1-6b2d-4c5a-b8f7-1d2e3c4b5a6f", null, "Driver", "DRIVER" },
                    { "e1f3c9a4-7d5b-4b2d-a2f7-9a1b2c3d4e5f", null, "DeliveryClient", "DELIVERYCLIENT" },
                    { "f2d4b1c7-8e6a-4f3c-b5a8-7d9e0f1a2b3c", null, "DeliveryCompanyUser", "DELIVERYCOMPANYUSER" }
                });

            migrationBuilder.InsertData(
                table: "ClientDeliveryOrderStatuses",
                columns: new[] { "Id", "ClientDeliveryOrderStatusId", "Description", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, null, "The Order is waiting to accepted delivery from the company", "Pending", "في الانتظار" },
                    { 2, null, "The Delivery Company Accepted Your Delivery Request For This Order", "Accepted", "موافقة" },
                    { 3, null, "The Delivery Company Rejected Your Delivery Request For This Order", "Rejected", "مرفوضة" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryOrderStatuses",
                columns: new[] { "Id", "Description", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "الطلب تم استلامه من العميل ويجب استلامه من السائق", "PendingPickup", "بانتظار يوم التسليم" },
                    { 2, "الطلب مع السائق في الطريق إلى العميل", "OnRoute", "في الطريق" },
                    { 3, "الطلب تم تسليمه للعميل بنجاح", "Delivered", "تم التسليم" },
                    { 4, "الطلب تم إلغاؤه قبل التسليم", "Canceled", "ملغي" },
                    { 5, "الطلب تم تأجيله من قبل شركة التوصيل", "Deferred", "مؤجل" },
                    { 6, "الطلب تم تأجيله من قبل العميل", "DeferredByClient", "مؤجل من العميل" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "Id", "Description", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "The Regular Delivery", "Regular Delivery", "التوصيل الطبيعي" },
                    { 2, "The Fast Delivery,In The Same Day Or Shorter Time Than Regular", "Fast Delivery", "التوصيل السريع" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrders_CityId",
                table: "ClientDeliveryOrders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrders_ClientDeliveryOrderStatusId",
                table: "ClientDeliveryOrders",
                column: "ClientDeliveryOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrders_DeliveryClientOrganizationId",
                table: "ClientDeliveryOrders",
                column: "DeliveryClientOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrders_DeliveryClientUserId",
                table: "ClientDeliveryOrders",
                column: "DeliveryClientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrders_DeliveryCompanyId",
                table: "ClientDeliveryOrders",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrders_DeliveryTypeId",
                table: "ClientDeliveryOrders",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryOrderStatuses_ClientDeliveryOrderStatusId",
                table: "ClientDeliveryOrderStatuses",
                column: "ClientDeliveryOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganizationCompaniesDeliveries_DeliveryClientOrganizationId",
                table: "ClientOrganizationCompaniesDeliveries",
                column: "DeliveryClientOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganizationCompaniesDeliveries_DeliveryCompanyId",
                table: "ClientOrganizationCompaniesDeliveries",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequestsToDevlieryCompanies_DeliveryClientOrganizationId",
                table: "ClientRequestsToDevlieryCompanies",
                column: "DeliveryClientOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequestsToDevlieryCompanies_DeliveryClientUserId",
                table: "ClientRequestsToDevlieryCompanies",
                column: "DeliveryClientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequestsToDevlieryCompanies_DeliveryCompanyId",
                table: "ClientRequestsToDevlieryCompanies",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientOrganizations_CityId",
                table: "DeliveryClientOrganizations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientOrganizations_CountryId",
                table: "DeliveryClientOrganizations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientOrganizations_OrganizationActivityId",
                table: "DeliveryClientOrganizations",
                column: "OrganizationActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientOrganizations_SerialNumber",
                table: "DeliveryClientOrganizations",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientOrgProducts_DeliveryClientOrganizationId",
                table: "DeliveryClientOrgProducts",
                column: "DeliveryClientOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientUsers_DeliveryClientOrganizationId",
                table: "DeliveryClientUsers",
                column: "DeliveryClientOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClientUsers_UserId1",
                table: "DeliveryClientUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanies_CityId",
                table: "DeliveryCompanies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanies_CountryId",
                table: "DeliveryCompanies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyCitiesPrices_CityId",
                table: "DeliveryCompanyCitiesPrices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyCitiesPrices_DeliveryCompanyId",
                table: "DeliveryCompanyCitiesPrices",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyDeliveryType_DeliveryTypesId",
                table: "DeliveryCompanyDeliveryType",
                column: "DeliveryTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyDeliveryTypes_DeliveryCompanyId",
                table: "DeliveryCompanyDeliveryTypes",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyDistancePrices_DeliveryCompanyId",
                table: "DeliveryCompanyDistancePrices",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyUsers_DeliveryCompanyId",
                table: "DeliveryCompanyUsers",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCompanyUsers_UserId1",
                table: "DeliveryCompanyUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderAddresses_ClientDeliveryOrderId",
                table: "DeliveryOrderAddresses",
                column: "ClientDeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_AcceptedFromUserId",
                table: "DeliveryOrders",
                column: "AcceptedFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_ClientDeliveryOrderId",
                table: "DeliveryOrders",
                column: "ClientDeliveryOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryCompanyId",
                table: "DeliveryOrders",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryOrderAddressId",
                table: "DeliveryOrders",
                column: "DeliveryOrderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryOrderStatusId",
                table: "DeliveryOrders",
                column: "DeliveryOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryTypeId",
                table: "DeliveryOrders",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DriverId",
                table: "DeliveryOrders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_OrderSerialNumber",
                table: "DeliveryOrders",
                column: "OrderSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverAssignments_AssignedBy",
                table: "DriverAssignments",
                column: "AssignedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DriverAssignments_DriverId",
                table: "DriverAssignments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DeliveryCompanyId",
                table: "Drivers",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId1",
                table: "Drivers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VechicalNumber",
                table: "Drivers",
                column: "VechicalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VechicalTypeId",
                table: "Drivers",
                column: "VechicalTypeId");
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
                name: "ClientOrganizationCompaniesDeliveries");

            migrationBuilder.DropTable(
                name: "ClientRequestsToDevlieryCompanies");

            migrationBuilder.DropTable(
                name: "DeliveryClientOrgProducts");

            migrationBuilder.DropTable(
                name: "DeliveryCompanyCitiesPrices");

            migrationBuilder.DropTable(
                name: "DeliveryCompanyDeliveryType");

            migrationBuilder.DropTable(
                name: "DeliveryCompanyDeliveryTypes");

            migrationBuilder.DropTable(
                name: "DeliveryCompanyDistancePrices");

            migrationBuilder.DropTable(
                name: "DeliveryOrders");

            migrationBuilder.DropTable(
                name: "DriverAssignments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DeliveryOrderAddresses");

            migrationBuilder.DropTable(
                name: "DeliveryOrderStatuses");

            migrationBuilder.DropTable(
                name: "DeliveryCompanyUsers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "ClientDeliveryOrders");

            migrationBuilder.DropTable(
                name: "VechicalTypes");

            migrationBuilder.DropTable(
                name: "ClientDeliveryOrderStatuses");

            migrationBuilder.DropTable(
                name: "DeliveryClientUsers");

            migrationBuilder.DropTable(
                name: "DeliveryCompanies");

            migrationBuilder.DropTable(
                name: "DeliveryTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DeliveryClientOrganizations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "OrganizationActivities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
