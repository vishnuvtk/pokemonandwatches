using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonNWatches.Data;
using PokemonNWatches.Interfaces;
using PokemonNWatches.Models;

namespace PokemonNWatches.Services
{
    public class BuildService : IBuildService
    {
        private readonly ApplicationDbContext _poke;

        public BuildService(ApplicationDbContext context)
        {
            _poke = context;
        }

        /// <summary>
        /// Retrieves a list of all Builds in the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains an IEnumerable{BuildDTO} of all Builds.
        /// </returns>
        public async Task<IEnumerable<BuildDTO>> ListBuilds()
        {
            return await _poke.Builds
                .Include(b => b.Pokemon)
                .Include(b => b.HeldItems)
                .Select(b => new BuildDTO
                {
                    BuildId = b.BuildId,
                    PokemonId = b.PokemonId,
                    PokemonUpdatedHP = b.PokemonUpdatedHP,
                    PokemonUpdatedAttack = b.PokemonUpdatedAttack,
                    PokemonUpdatedDefense = b.PokemonUpdatedDefense,
                    PokemonUpdatedSpAttack = b.PokemonUpdatedSpAttack,
                    PokemonUpdatedSpDefense = b.PokemonUpdatedSpDefense,
                    PokemonUpdatedCDR = b.PokemonUpdatedCDR,
                    Pokemon = new PokemonDTO
                    {
                        PokemonId = b.Pokemon.PokemonId,
                        PokemonName = b.Pokemon.PokemonName
                    },
                    HeldItems = b.HeldItems.Select(h => new HeldItemDTO
                    {
                        HeldItemId = h.HeldItemId,
                        HeldItemName = h.HeldItemName
                    }).ToList()
                })
                .ToListAsync();
        }

        /// <summary>
        /// Finds a specific Build by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Build to find.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "BuildDTO" if found; otherwise, null.
        /// </returns>
        public async Task<BuildDTO> FindBuilds(int id)
        {
            var build = await _poke.Builds
                .Include(b => b.Pokemon)
                .Include(b => b.HeldItems)
                .FirstOrDefaultAsync(b => b.BuildId == id);

            if (build == null) return null;

            return new BuildDTO
            {
                BuildId = build.BuildId,
                PokemonId = build.PokemonId,
                PokemonUpdatedHP = build.PokemonUpdatedHP,
                PokemonUpdatedAttack = build.PokemonUpdatedAttack,
                PokemonUpdatedDefense = build.PokemonUpdatedDefense,
                PokemonUpdatedSpAttack = build.PokemonUpdatedSpAttack,
                PokemonUpdatedSpDefense = build.PokemonUpdatedSpDefense,
                PokemonUpdatedCDR = build.PokemonUpdatedCDR,
                Pokemon = new PokemonDTO
                {
                    PokemonId = build.Pokemon.PokemonId,
                    PokemonName = build.Pokemon.PokemonName
                },
                HeldItems = build.HeldItems.Select(h => new HeldItemDTO
                {
                    HeldItemId = h.HeldItemId,
                    HeldItemName = h.HeldItemName
                }).ToList()
            };
        }

        /// <summary>
        /// Creates a new Build entry in the database.
        /// </summary>
        /// <param name="buildDto">The data transfer object containing Build information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task CreateBuilds(BuildDTO buildDto)
        {
            var build = new Build
            {
                PokemonId = buildDto.PokemonId,
                PokemonUpdatedHP = buildDto.PokemonUpdatedHP,
                PokemonUpdatedAttack = buildDto.PokemonUpdatedAttack,
                PokemonUpdatedDefense = buildDto.PokemonUpdatedDefense,
                PokemonUpdatedSpAttack = buildDto.PokemonUpdatedSpAttack,
                PokemonUpdatedSpDefense = buildDto.PokemonUpdatedSpDefense,
                PokemonUpdatedCDR = buildDto.PokemonUpdatedCDR,
                HeldItems = buildDto.HeldItems.Select(h => new HeldItem
                {
                    HeldItemId = h.HeldItemId,
                    HeldItemName = h.HeldItemName
                }).ToList()
            };

            _poke.Builds.Add(build);
            await _poke.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing Build entry in the database.
        /// </summary>
        /// <param name="buildDto">The data transfer object containing updated Build information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains "true" if the update is successful; otherwise, "false".
        /// </returns>
        public async Task<bool> UpdateBuilds(BuildDTO buildDto)
        {
            var build = await _poke.Builds
                .Include(b => b.HeldItems)
                .FirstOrDefaultAsync(b => b.BuildId == buildDto.BuildId);

            if (build == null) return false;

            build.PokemonUpdatedHP = buildDto.PokemonUpdatedHP;
            build.PokemonUpdatedAttack = buildDto.PokemonUpdatedAttack;
            build.PokemonUpdatedDefense = buildDto.PokemonUpdatedDefense;
            build.PokemonUpdatedSpAttack = buildDto.PokemonUpdatedSpAttack;
            build.PokemonUpdatedSpDefense = buildDto.PokemonUpdatedSpDefense;
            build.PokemonUpdatedCDR = buildDto.PokemonUpdatedCDR;

            build.HeldItems.Clear();
            foreach (var heldItemDto in buildDto.HeldItems)
            {
                var heldItem = await _poke.HeldItems.FindAsync(heldItemDto.HeldItemId);
                if (heldItem != null) build.HeldItems.Add(heldItem);
            }

            _poke.Builds.Update(build);
            await _poke.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Deletes a specific Build entry from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Build to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains "true" if deletion is successful; otherwise, "false".
        /// </returns>
        public async Task<bool> DeleteBuilds(int id)
        {
            var build = await _poke.Builds.FindAsync(id);
            if (build == null) return false;

            _poke.Builds.Remove(build);
            await _poke.SaveChangesAsync();

            return true;
        }
    }
}
