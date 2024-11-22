using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokemonNWatches.ViewModels
{
    public class HeldItemViewModel
    {
        public int HeldItemId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string HeldItemName { get; set; }
        public int HeldItemHP { get; set; }
        public int HeldItemAttack { get; set; }
        public int HeldItemDefense { get; set; }
        public int HeldItemSpAttack { get; set; }
        public int HeldItemSpDefense { get; set; }
        public int HeldItemCDR { get; set; }

        // Builds using this Held Item
        public IEnumerable<BuildViewModel> Builds { get; set; }
    }
}
