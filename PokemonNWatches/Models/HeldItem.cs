﻿using System.ComponentModel.DataAnnotations;

namespace PokemonNWatches.Models
{
    public class HeldItem
    {
        [Key]
        public int HeldItemId { get; set; }
        public string HeldItemName { get; set; }
        public int HeldItemHP { get; set; }
        public int HeldItemAttack { get; set; }
        public int HeldItemDefense { get; set; }
        public int HeldItemSpAttack { get; set; }
        public int HeldItemSpDefense { get; set; }
        public int HeldItemCDR { get; set; }

        ///public string HeldItemImgLink { get; set; }
        ///public int HeldItemCritRate { get; set; }        
        ///public int HeldItemLifesteal { get; set; }
        ///public int HeldItemAttackSpeed { get; set; }
        ///public int HeldItemMoveSpeed { get; set; }

        // a held item can be attached to multiple pokemons
        public ICollection<Pokemon>? Pokemons { get; set; }

        // a held item can be attached to multiple buildss
        public ICollection<Build> Builds { get; set; }

    }
}

public class HeldItemDTO
{
    public int HeldItemId { get; set; }
    public string HeldItemName { get; set; }
    public int HeldItemHP { get; set; }
    public int HeldItemAttack { get; set; }
    public int HeldItemDefense { get; set; }
    public int HeldItemSpAttack { get; set; }
    public int HeldItemSpDefense { get; set; }
    public int HeldItemCDR { get; set; }

    public virtual ICollection<BuildDTO> Builds { get; set; } = new List<BuildDTO>();
}
