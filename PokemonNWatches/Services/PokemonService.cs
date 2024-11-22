using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonNWatches.Data;
using PokemonNWatches.Interfaces;
using PokemonNWatches.Models;

namespace PokemonNWatches.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly ApplicationDbContext _poke;

        // initializes a new instance of the class
        public PokemonService(ApplicationDbContext poke)
        {
            _poke = poke;
        }

        /// <summary>
        /// Retrieves a list of all Pokémon in the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains an IEnumerable{PokemonDTO} of all Pokémon.
        /// </returns>
        public async Task<IEnumerable<PokemonDTO>> ListPokemons()
        {
            return await _poke.Pokemons.Select(p => new PokemonDTO
                {
                    PokemonId = p.PokemonId,
                    PokemonName = p.PokemonName,
                    PokemonRole = p.PokemonRole,
                    PokemonStyle = p.PokemonStyle,
                    PokemonHP = p.PokemonHP,
                    PokemonAttack = p.PokemonAttack,
                    PokemonDefense = p.PokemonDefense,
                    PokemonSpAttack = p.PokemonSpAttack,
                    PokemonSpDefense = p.PokemonSpDefense,
                    PokemonCDR = p.PokemonCDR
                })
                .ToListAsync();
        }

        /// <summary>
        /// Finds a specific Pokémon by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to find.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "PokemonDTO" if found; otherwise, null.
        /// </returns>
        public async Task<PokemonDTO> FindPokemon(int id)
        {
            var pokemon = await _poke.Pokemons.FindAsync(id);
            if (pokemon == null) return null;

            return new PokemonDTO
            {
                PokemonId = pokemon.PokemonId,
                PokemonName = pokemon.PokemonName,
                PokemonRole = pokemon.PokemonRole,
                PokemonStyle = pokemon.PokemonStyle,
                PokemonHP = pokemon.PokemonHP,
                PokemonAttack = pokemon.PokemonAttack,
                PokemonDefense = pokemon.PokemonDefense,
                PokemonSpAttack = pokemon.PokemonSpAttack,
                PokemonSpDefense = pokemon.PokemonSpDefense,
                PokemonCDR = pokemon.PokemonCDR
            };
        }

        /// <summary>
        /// Creates a new Pokémon entry in the database.
        /// </summary>
        /// <param name="pokemonDTO">The data transfer object containing Pokémon information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the created "PokemonDTO" with its assigned identifier.
        /// </returns>
        public async Task<PokemonDTO> CreatePokemon(PokemonDTO pokemonDTO)
        {
            var pokemon = new Pokemon
            {
                PokemonName = pokemonDTO.PokemonName,
                PokemonRole = pokemonDTO.PokemonRole,
                PokemonStyle = pokemonDTO.PokemonStyle,
                PokemonHP = pokemonDTO.PokemonHP,
                PokemonAttack = pokemonDTO.PokemonAttack,
                PokemonDefense = pokemonDTO.PokemonDefense,
                PokemonSpAttack = pokemonDTO.PokemonSpAttack,
                PokemonSpDefense = pokemonDTO.PokemonSpDefense,
                PokemonCDR = pokemonDTO.PokemonCDR
            };

            _poke.Pokemons.Add(pokemon);
            await _poke.SaveChangesAsync();

            pokemonDTO.PokemonId = pokemon.PokemonId;
            return pokemonDTO;
        }

        /// <summary>
        /// Updates an existing Pokémon entry in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to update.</param>
        /// <param name="pokemonDTO">The data transfer object containing updated Pokémon information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains "true"" if the update is successful; otherwise, "false".
        /// </returns>
        public async Task<bool> UpdatePokemon(int id, PokemonDTO pokemonDTO)
        {
            if (id != pokemonDTO.PokemonId) return false;

            var pokemon = await _poke.Pokemons.FindAsync(id);
            if (pokemon == null) return false;

            pokemon.PokemonName = pokemonDTO.PokemonName;
            pokemon.PokemonRole = pokemonDTO.PokemonRole;
            pokemon.PokemonStyle = pokemonDTO.PokemonStyle;
            pokemon.PokemonHP = pokemonDTO.PokemonHP;
            pokemon.PokemonAttack = pokemonDTO.PokemonAttack;
            pokemon.PokemonDefense = pokemonDTO.PokemonDefense;
            pokemon.PokemonSpAttack = pokemonDTO.PokemonSpAttack;
            pokemon.PokemonSpDefense = pokemonDTO.PokemonSpDefense;
            pokemon.PokemonCDR = pokemonDTO.PokemonCDR;

            _poke.Pokemons.Update(pokemon);

            try
            {
                await _poke.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id)) return false;
                else throw;
            }
        }

        /// <summary>
        /// Deletes a specific Pokémon entry from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains true if deletion is successful; otherwise, "false"".
        /// </returns>
        public async Task<bool> DeletePokemon(int id)
        {
            var pokemon = await _poke.Pokemons.FindAsync(id);
            if (pokemon == null) return false;

            _poke.Pokemons.Remove(pokemon);
            await _poke.SaveChangesAsync();

            return true;
        }

        // Checks whether a Pokémon with the specified identifier exists in the database.
        private bool PokemonExists(int id)
        {
            return _poke.Pokemons.Any(e => e.PokemonId == id);
        }
    }
}
