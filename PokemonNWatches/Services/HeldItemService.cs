using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonNWatches.Data;
using PokemonNWatches.Interfaces;
using PokemonNWatches.Models;

namespace PokemonNWatches.Services
{
    public class HeldItemService : IHeldItemService
    {
        private readonly ApplicationDbContext _poke;

        public HeldItemService(ApplicationDbContext poke)
        {
            _poke = poke;
        }

        /// <summary>
        /// Retrieves a list of all Held Items in the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains an IEnumerable{HeldItemDTO} of all Held Items.
        /// </returns>
        public async Task<IEnumerable<HeldItemDTO>> ListHeldItems()
        {
            return await _poke.HeldItems.Select(h => new HeldItemDTO
            {
                HeldItemId = h.HeldItemId,
                HeldItemName = h.HeldItemName,
                HeldItemHP = h.HeldItemHP,
                HeldItemAttack = h.HeldItemAttack,
                HeldItemDefense = h.HeldItemDefense,
                HeldItemSpAttack = h.HeldItemSpAttack,
                HeldItemSpDefense = h.HeldItemSpDefense,
                HeldItemCDR = h.HeldItemCDR
            })
                .ToListAsync();
        }

        /// <summary>
        /// Finds a specific Held Item by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to find.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "HeldItemDTO" if found; otherwise, null.
        /// </returns>
        public async Task<HeldItemDTO> FindHeldItem(int id)
        {
            var heldItem = await _poke.HeldItems.FindAsync(id);
            if (heldItem == null) return null;

            return new HeldItemDTO
            {
                HeldItemId = heldItem.HeldItemId,
                HeldItemName = heldItem.HeldItemName,
                HeldItemHP = heldItem.HeldItemHP,
                HeldItemAttack = heldItem.HeldItemAttack,
                HeldItemDefense = heldItem.HeldItemDefense,
                HeldItemSpAttack = heldItem.HeldItemSpAttack,
                HeldItemSpDefense = heldItem.HeldItemSpDefense,
                HeldItemCDR = heldItem.HeldItemCDR
            };
        }

        /// <summary>
        /// Creates a new Held Item entry in the database.
        /// </summary>
        /// <param name="heldItemDTO">The data transfer object containing Held Item information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the created "HeldItemDTO" with its assigned identifier.
        /// </returns>
        public async Task<HeldItemDTO> CreateHeldItem(HeldItemDTO heldItemDTO)
        {
            var heldItem = new HeldItem
            {
                HeldItemName = heldItemDTO.HeldItemName,
                HeldItemHP = heldItemDTO.HeldItemHP,
                HeldItemAttack = heldItemDTO.HeldItemAttack,
                HeldItemDefense = heldItemDTO.HeldItemDefense,
                HeldItemSpAttack = heldItemDTO.HeldItemSpAttack,
                HeldItemSpDefense = heldItemDTO.HeldItemSpDefense,
                HeldItemCDR = heldItemDTO.HeldItemCDR
            };

            _poke.HeldItems.Add(heldItem);
            await _poke.SaveChangesAsync();

            heldItemDTO.HeldItemId = heldItem.HeldItemId;
            return heldItemDTO;
        }

        /// <summary>
        /// Updates an existing Held Item entry in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to update.</param>
        /// <param name="heldItemDTO">The data transfer object containing updated Held Item information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains "true" if the update is successful; otherwise, "false".
        /// </returns>
        public async Task<bool> UpdateHeldItem(int id, HeldItemDTO heldItemDTO)
        {
            if (id != heldItemDTO.HeldItemId) return false;

            var heldItem = await _poke.HeldItems.FindAsync(id);
            if (heldItem == null) return false;

            heldItem.HeldItemName = heldItemDTO.HeldItemName;
            heldItem.HeldItemHP = heldItemDTO.HeldItemHP;
            heldItem.HeldItemAttack = heldItemDTO.HeldItemAttack;
            heldItem.HeldItemDefense = heldItemDTO.HeldItemDefense;
            heldItem.HeldItemSpAttack = heldItemDTO.HeldItemSpAttack;
            heldItem.HeldItemSpDefense = heldItemDTO.HeldItemSpDefense;
            heldItem.HeldItemCDR = heldItemDTO.HeldItemCDR;

            _poke.HeldItems.Update(heldItem);

            try
            {
                await _poke.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeldItemExists(id)) return false;
                else throw;
            }
        }

        /// <summary>
        /// Deletes a specific Held Item entry from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains "true" if deletion is successful; otherwise, "false".
        /// </returns>
        public async Task<bool> DeleteHeldItem(int id)
        {
            var heldItem = await _poke.HeldItems.FindAsync(id);
            if (heldItem == null) return false;

            _poke.HeldItems.Remove(heldItem);
            await _poke.SaveChangesAsync();

            return true;
        }

        // Checks whether a Held Item with the specified identifier exists in the database.
        private bool HeldItemExists(int id)
        {
            return _poke.HeldItems.Any(e => e.HeldItemId == id);
        }
    }
}
