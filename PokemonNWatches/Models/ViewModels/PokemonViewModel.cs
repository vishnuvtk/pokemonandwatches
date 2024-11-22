using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PokemonNWatches.ViewModels
{
    public class PokemonViewModel
    {
        public int PokemonId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string PokemonName { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string PokemonRole { get; set; }
        [Required]
        [Display(Name = "Style")]
        public string PokemonStyle { get; set; }
        public int PokemonHP { get; set; }
        public int PokemonAttack { get; set; }
        public int PokemonDefense { get; set; }
        public int PokemonSpAttack { get; set; }
        public int PokemonSpDefense { get; set; }
        public int PokemonCDR { get; set; }

        // Related Builds
        public IEnumerable<BuildViewModel> Builds { get; set; }
    }
}
