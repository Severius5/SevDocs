using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace SevDocs.Stores.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
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
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: true),
                    LastName = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "character varying(26)", nullable: false),
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
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false)
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
                name: "AspNetUserPasskeys",
                columns: table => new
                {
                    CredentialId = table.Column<byte[]>(type: "bytea", maxLength: 1024, nullable: false),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Data = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserPasskeys", x => x.CredentialId);
                    table.ForeignKey(
                        name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false),
                    RoleId = table.Column<string>(type: "character varying(26)", nullable: false)
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
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
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
                name: "EquipmentEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagCategoryEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategoryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagCategoryEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PersonId = table.Column<string>(type: "character varying(26)", nullable: true),
                    OrganizationId = table.Column<string>(type: "character varying(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEntity_OrganizationEntity_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "OrganizationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactEntity_PersonEntity_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IdHash = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IsNew = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: true)
                        .Annotation("Npgsql:TsVectorConfig", "simple")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "Title", "Notes" }),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false),
                    SenderPersonId = table.Column<string>(type: "character varying(26)", nullable: true),
                    ReceiverPersonId = table.Column<string>(type: "character varying(26)", nullable: true),
                    EquipmentId = table.Column<string>(type: "character varying(26)", nullable: true),
                    SenderOrganizationId = table.Column<string>(type: "character varying(26)", nullable: true),
                    ReceiverOrganizationId = table.Column<string>(type: "character varying(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderEntity_EquipmentEntity_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "EquipmentEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolderEntity_OrganizationEntity_ReceiverOrganizationId",
                        column: x => x.ReceiverOrganizationId,
                        principalTable: "OrganizationEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolderEntity_OrganizationEntity_SenderOrganizationId",
                        column: x => x.SenderOrganizationId,
                        principalTable: "OrganizationEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolderEntity_PersonEntity_ReceiverPersonId",
                        column: x => x.ReceiverPersonId,
                        principalTable: "PersonEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolderEntity_PersonEntity_SenderPersonId",
                        column: x => x.SenderPersonId,
                        principalTable: "PersonEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TagCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    UserId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagEntity_TagCategoryEntity_TagCategoryId",
                        column: x => x.TagCategoryId,
                        principalTable: "TagCategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TextContent = table.Column<string>(type: "text", nullable: true),
                    ConvertedName = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: true),
                    CoverName = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: true),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: true)
                        .Annotation("Npgsql:TsVectorConfig", "simple")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "TextContent" }),
                    Checksum = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    FolderId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEntity_FolderEntity_FolderId",
                        column: x => x.FolderId,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderEntityFolderEntity",
                columns: table => new
                {
                    LinkedById = table.Column<string>(type: "character varying(26)", nullable: false),
                    LinksId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderEntityFolderEntity", x => new { x.LinkedById, x.LinksId });
                    table.ForeignKey(
                        name: "FK_FolderEntityFolderEntity_FolderEntity_LinkedById",
                        column: x => x.LinkedById,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderEntityFolderEntity_FolderEntity_LinksId",
                        column: x => x.LinksId,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderLinkEntity",
                columns: table => new
                {
                    FolderLinksId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FolderLinkedId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderLinkEntity", x => new { x.FolderLinksId, x.FolderLinkedId });
                    table.ForeignKey(
                        name: "FK_FolderLinkEntity_FolderEntity_FolderLinkedId",
                        column: x => x.FolderLinkedId,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderLinkEntity_FolderEntity_FolderLinksId",
                        column: x => x.FolderLinksId,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderEntityTagEntity",
                columns: table => new
                {
                    FoldersId = table.Column<string>(type: "character varying(26)", nullable: false),
                    TagsId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderEntityTagEntity", x => new { x.FoldersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_FolderEntityTagEntity_FolderEntity_FoldersId",
                        column: x => x.FoldersId,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderEntityTagEntity_TagEntity_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TagEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderTagEntity",
                columns: table => new
                {
                    FolderId = table.Column<string>(type: "character varying(26)", nullable: false),
                    TagId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderTagEntity", x => new { x.FolderId, x.TagId });
                    table.ForeignKey(
                        name: "FK_FolderTagEntity_FolderEntity_FolderId",
                        column: x => x.FolderId,
                        principalTable: "FolderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderTagEntity_TagEntity_TagId",
                        column: x => x.TagId,
                        principalTable: "TagEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetUserPasskeys_UserId",
                table: "AspNetUserPasskeys",
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
                name: "IX_ContactEntity_OrganizationId",
                table: "ContactEntity",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactEntity_PersonId",
                table: "ContactEntity",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_FolderId",
                table: "DocumentEntity",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_SearchVector",
                table: "DocumentEntity",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentEntity_UserId",
                table: "EquipmentEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_EquipmentId",
                table: "FolderEntity",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_ReceiverOrganizationId",
                table: "FolderEntity",
                column: "ReceiverOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_ReceiverPersonId",
                table: "FolderEntity",
                column: "ReceiverPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_SearchVector",
                table: "FolderEntity",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_SenderOrganizationId",
                table: "FolderEntity",
                column: "SenderOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_SenderPersonId",
                table: "FolderEntity",
                column: "SenderPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntity_UserId",
                table: "FolderEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntityFolderEntity_LinksId",
                table: "FolderEntityFolderEntity",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderEntityTagEntity_TagsId",
                table: "FolderEntityTagEntity",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderLinkEntity_FolderLinkedId",
                table: "FolderLinkEntity",
                column: "FolderLinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderTagEntity_TagId",
                table: "FolderTagEntity",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEntity_UserId",
                table: "OrganizationEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEntity_UserId",
                table: "PersonEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagCategoryEntity_UserId",
                table: "TagCategoryEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEntity_TagCategoryId",
                table: "TagEntity",
                column: "TagCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEntity_UserId",
                table: "TagEntity",
                column: "UserId");
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
                name: "AspNetUserPasskeys");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactEntity");

            migrationBuilder.DropTable(
                name: "DocumentEntity");

            migrationBuilder.DropTable(
                name: "FolderEntityFolderEntity");

            migrationBuilder.DropTable(
                name: "FolderEntityTagEntity");

            migrationBuilder.DropTable(
                name: "FolderLinkEntity");

            migrationBuilder.DropTable(
                name: "FolderTagEntity");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FolderEntity");

            migrationBuilder.DropTable(
                name: "TagEntity");

            migrationBuilder.DropTable(
                name: "EquipmentEntity");

            migrationBuilder.DropTable(
                name: "OrganizationEntity");

            migrationBuilder.DropTable(
                name: "PersonEntity");

            migrationBuilder.DropTable(
                name: "TagCategoryEntity");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
