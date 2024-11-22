using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonNWatches.Data.Migrations
{
    /// <inheritdoc />
    public partial class build : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    BuildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonUpdatedHP = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedAttack = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedDefense = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedSpAttack = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedSpDefense = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedCritRate = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedCDR = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedLifesteal = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedAttackSpeed = table.Column<int>(type: "int", nullable: false),
                    PokemonUpdatedMoveSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.BuildId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Builds");
        }
    }
}
