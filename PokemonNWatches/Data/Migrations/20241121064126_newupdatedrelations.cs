using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonNWatches.Data.Migrations
{
    /// <inheritdoc />
    public partial class newupdatedrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "Builds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildHeldItem",
                columns: table => new
                {
                    BuildsBuildId = table.Column<int>(type: "int", nullable: false),
                    HeldItemsHeldItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildHeldItem", x => new { x.BuildsBuildId, x.HeldItemsHeldItemId });
                    table.ForeignKey(
                        name: "FK_BuildHeldItem_Builds_BuildsBuildId",
                        column: x => x.BuildsBuildId,
                        principalTable: "Builds",
                        principalColumn: "BuildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildHeldItem_HeldItems_HeldItemsHeldItemId",
                        column: x => x.HeldItemsHeldItemId,
                        principalTable: "HeldItems",
                        principalColumn: "HeldItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeldItemPokemon",
                columns: table => new
                {
                    HeldItemsHeldItemId = table.Column<int>(type: "int", nullable: false),
                    PokemonsPokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeldItemPokemon", x => new { x.HeldItemsHeldItemId, x.PokemonsPokemonId });
                    table.ForeignKey(
                        name: "FK_HeldItemPokemon_HeldItems_HeldItemsHeldItemId",
                        column: x => x.HeldItemsHeldItemId,
                        principalTable: "HeldItems",
                        principalColumn: "HeldItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeldItemPokemon_Pokemons_PokemonsPokemonId",
                        column: x => x.PokemonsPokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Builds_PokemonId",
                table: "Builds",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildHeldItem_HeldItemsHeldItemId",
                table: "BuildHeldItem",
                column: "HeldItemsHeldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HeldItemPokemon_PokemonsPokemonId",
                table: "HeldItemPokemon",
                column: "PokemonsPokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Pokemons_PokemonId",
                table: "Builds",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "PokemonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Pokemons_PokemonId",
                table: "Builds");

            migrationBuilder.DropTable(
                name: "BuildHeldItem");

            migrationBuilder.DropTable(
                name: "HeldItemPokemon");

            migrationBuilder.DropIndex(
                name: "IX_Builds_PokemonId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Builds");
        }
    }
}
