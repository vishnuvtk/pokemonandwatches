﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonNWatches.Models;

namespace PokemonNWatches.Interfaces
{
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDTO>> ListPokemons();
        Task<PokemonDTO> FindPokemon(int id);
        Task<PokemonDTO> CreatePokemon(PokemonDTO pokemonDTO);
        Task<bool> UpdatePokemon(int id, PokemonDTO pokemonDTO);
        Task<bool> DeletePokemon(int id);
    }
}
