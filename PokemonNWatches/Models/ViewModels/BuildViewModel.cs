using System.Collections.Generic;

namespace PokemonNWatches.ViewModels
{
    public class BuildViewModel
    {
        public int BuildId { get; set; }
        public int PokemonUpdatedHP { get; set; }
        public int PokemonUpdatedAttack { get; set; }
        public int PokemonUpdatedDefense { get; set; }
        public int PokemonUpdatedSpAttack { get; set; }
        public int PokemonUpdatedSpDefense { get; set; }
        public int PokemonUpdatedCDR { get; set; }

        // Associated Pokémon
        public int PokemonId { get; set; }
        public string PokemonName { get; set; }

        // Held Items in this Build
        public IEnumerable<HeldItemViewModel> HeldItems { get; set; }
    }
}
