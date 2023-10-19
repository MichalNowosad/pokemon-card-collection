using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCardCollection.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardAbilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardAttacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Power = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAttacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardsAmount = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expansions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illustrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illustrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthPoints = table.Column<int>(type: "int", nullable: false),
                    PokemonDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EnergyType = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    ExpansionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IllustratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonCards_CardAbilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "CardAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCards_Expansions_ExpansionId",
                        column: x => x.ExpansionId,
                        principalTable: "Expansions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCards_Illustrators_IllustratorId",
                        column: x => x.IllustratorId,
                        principalTable: "Illustrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    ExpansionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IllustratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerCards_Expansions_ExpansionId",
                        column: x => x.ExpansionId,
                        principalTable: "Expansions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCards_Illustrators_IllustratorId",
                        column: x => x.IllustratorId,
                        principalTable: "Illustrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardAttacks",
                columns: table => new
                {
                    CardAttackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PokemonCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardAttacks", x => new { x.CardAttackId, x.PokemonCardId });
                    table.ForeignKey(
                        name: "FK_PokemonCardAttacks_CardAttacks_CardAttackId",
                        column: x => x.CardAttackId,
                        principalTable: "CardAttacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardAttacks_PokemonCards_PokemonCardId",
                        column: x => x.PokemonCardId,
                        principalTable: "PokemonCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardAttacks_PokemonCardId",
                table: "PokemonCardAttacks",
                column: "PokemonCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCards_AbilityId",
                table: "PokemonCards",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCards_ExpansionId",
                table: "PokemonCards",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCards_IllustratorId",
                table: "PokemonCards",
                column: "IllustratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCards_ExpansionId",
                table: "TrainerCards",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCards_IllustratorId",
                table: "TrainerCards",
                column: "IllustratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCardAttacks");

            migrationBuilder.DropTable(
                name: "TrainerCards");

            migrationBuilder.DropTable(
                name: "CardAttacks");

            migrationBuilder.DropTable(
                name: "PokemonCards");

            migrationBuilder.DropTable(
                name: "CardAbilities");

            migrationBuilder.DropTable(
                name: "Expansions");

            migrationBuilder.DropTable(
                name: "Illustrators");
        }
    }
}
