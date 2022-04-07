using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWebAPI.Migrations
{
    public partial class InitialDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Fights = table.Column<int>(type: "int", nullable: false),
                    Victories = table.Column<int>(type: "int", nullable: false),
                    Defeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 30, "Fireball" },
                    { 2, 20, "Frenzy" },
                    { 3, 50, "Blizzard" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, new byte[] { 133, 235, 82, 41, 56, 128, 254, 145, 10, 141, 0, 95, 99, 15, 241, 73, 203, 109, 139, 165, 244, 101, 163, 201, 17, 214, 52, 160, 25, 230, 240, 206, 42, 160, 147, 31, 226, 245, 86, 19, 230, 45, 175, 19, 90, 5, 45, 217, 227, 99, 250, 49, 130, 18, 253, 153, 193, 124, 57, 149, 181, 216, 61, 230 }, new byte[] { 44, 192, 0, 104, 227, 134, 182, 101, 97, 14, 75, 163, 149, 139, 84, 170, 235, 76, 194, 9, 190, 186, 55, 15, 41, 93, 163, 102, 81, 151, 3, 57, 53, 189, 76, 189, 157, 64, 15, 150, 125, 216, 11, 74, 66, 243, 39, 116, 109, 66, 102, 61, 2, 46, 166, 108, 132, 217, 189, 0, 60, 190, 109, 148, 115, 115, 111, 172, 92, 87, 36, 27, 151, 161, 215, 46, 180, 65, 247, 54, 109, 48, 67, 94, 16, 232, 184, 99, 117, 138, 116, 172, 226, 236, 151, 255, 130, 117, 105, 144, 245, 215, 226, 175, 142, 135, 245, 7, 11, 181, 71, 18, 112, 58, 160, 68, 148, 192, 126, 6, 101, 222, 180, 174, 88, 205, 182, 90 }, "User1" },
                    { 2, new byte[] { 133, 235, 82, 41, 56, 128, 254, 145, 10, 141, 0, 95, 99, 15, 241, 73, 203, 109, 139, 165, 244, 101, 163, 201, 17, 214, 52, 160, 25, 230, 240, 206, 42, 160, 147, 31, 226, 245, 86, 19, 230, 45, 175, 19, 90, 5, 45, 217, 227, 99, 250, 49, 130, 18, 253, 153, 193, 124, 57, 149, 181, 216, 61, 230 }, new byte[] { 44, 192, 0, 104, 227, 134, 182, 101, 97, 14, 75, 163, 149, 139, 84, 170, 235, 76, 194, 9, 190, 186, 55, 15, 41, 93, 163, 102, 81, 151, 3, 57, 53, 189, 76, 189, 157, 64, 15, 150, 125, 216, 11, 74, 66, 243, 39, 116, 109, 66, 102, 61, 2, 46, 166, 108, 132, 217, 189, 0, 60, 190, 109, 148, 115, 115, 111, 172, 92, 87, 36, 27, 151, 161, 215, 46, 180, 65, 247, 54, 109, 48, 67, 94, 16, 232, 184, 99, 117, 138, 116, 172, 226, 236, 151, 255, 130, 117, 105, 144, 245, 215, 226, 175, 142, 135, 245, 7, 11, 181, 71, 18, 112, 58, 160, 68, 148, 192, 126, 6, 101, 222, 180, 174, 88, 205, 182, 90 }, "User2" }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("57a679bb-ec69-4a54-b19a-f245e3f2b48a"), 20, "The Master Sword" },
                    { 2, new Guid("ecd37a20-5620-41ec-afd6-cf09ec25d8cc"), 5, "Crystal Wand" }
                });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("5355c1a8-bb0c-49f1-bc2c-b8c8ce2539f9"), 1 },
                    { new Guid("a1b7697d-3a1a-45e3-8d8e-6447cb1a8b19"), 2 },
                    { new Guid("d2d33062-e77b-4b10-8b8c-44e20ef44b93"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "PublishedAt", "Strength", "UserId", "Victories" },
                values: new object[,]
                {
                    { new Guid("1bc19437-5989-4ac6-a07b-d058fbf45648"), 2, 0, 5, 0, 100, 20, "Raistlin", new DateTime(2022, 4, 7, 13, 27, 54, 379, DateTimeKind.Local).AddTicks(4356), 5, 2, 0 },
                    { new Guid("6f2f59d9-44b5-4b84-9e64-c6f1ec295d0a"), 1, 0, 10, 0, 100, 10, "Frodo", new DateTime(2022, 4, 7, 13, 27, 54, 379, DateTimeKind.Local).AddTicks(4318), 15, 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
