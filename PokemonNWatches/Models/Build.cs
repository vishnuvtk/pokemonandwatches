using System.ComponentModel.DataAnnotations;

namespace PokemonNWatches.Models
{
    public class Build
    {
        [Key]
        public int BuildId { get; set; }
        public int PokemonUpdatedHP { get; set; }
        public int PokemonUpdatedAttack { get; set; }
        public int PokemonUpdatedDefense { get; set; }
        public int PokemonUpdatedSpAttack { get; set; }
        public int PokemonUpdatedSpDefense { get; set; }
        public int PokemonUpdatedCDR { get; set; }

        ///public int PokemonUpdatedCritRate { get; set; }
        ///public int PokemonUpdatedLifesteal { get; set; }
        ///public int PokemonUpdatedAttackSpeed { get; set; }
        ///public int PokemonUpdatedMoveSpeed { get; set; }

        // a build can have one pokemon
        public int PokemonId { get; set; }
        public virtual Pokemon Pokemon { get; set; }

        // a build can have 3 (multiple) held items
        public virtual ICollection<HeldItem> HeldItems { get; set; } = new List<HeldItem>();

        // a build can have one battle item
        /*public IEnumerable<BattleItem> BattleItems { get; set; }*/

    }
}

public class BuildDTO
{
    public int BuildId { get; set; }

    // Updated stats
    public int PokemonUpdatedHP { get; set; }
    public int PokemonUpdatedAttack { get; set; }
    public int PokemonUpdatedDefense { get; set; }
    public int PokemonUpdatedSpAttack { get; set; }
    public int PokemonUpdatedSpDefense { get; set; }
    public int PokemonUpdatedCDR { get; set; }

    // Associated Pokémon
    public int PokemonId { get; set; }
    public PokemonDTO Pokemon { get; set; }

    // Associated Held Items
    public List<HeldItemDTO> HeldItems { get; set; }
}

