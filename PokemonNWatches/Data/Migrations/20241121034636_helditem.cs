using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonNWatches.Data.Migrations
{
    /// <inheritdoc />
    public partial class helditem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeldItemId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HeldItems",
                columns: table => new
                {
                    HeldItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeldItemImgLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeldItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeldItemHP = table.Column<int>(type: "int", nullable: false),
                    HeldItemAttack = table.Column<int>(type: "int", nullable: false),
                    HeldItemDefense = table.Column<int>(type: "int", nullable: false),
                    HeldItemSpAttack = table.Column<int>(type: "int", nullable: false),
                    HeldItemSpDefense = table.Column<int>(type: "int", nullable: false),
                    HeldItemCritRate = table.Column<int>(type: "int", nullable: false),
                    HeldItemCDR = table.Column<int>(type: "int", nullable: false),
                    HeldItemLifesteal = table.Column<int>(type: "int", nullable: false),
                    HeldItemAttackSpeed = table.Column<int>(type: "int", nullable: false),
                    HeldItemMoveSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeldItems", x => x.HeldItemId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_HeldItemId",
                table: "Pokemons",
                column: "HeldItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_HeldItems_HeldItemId",
                table: "Pokemons",
                column: "HeldItemId",
                principalTable: "HeldItems",
                principalColumn: "HeldItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_HeldItems_HeldItemId",
                table: "Pokemons");

            migrationBuilder.DropTable(
                name: "HeldItems");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_HeldItemId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "HeldItemId",
                table: "Pokemons");
        }
    }
}
