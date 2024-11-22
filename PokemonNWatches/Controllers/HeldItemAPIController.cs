using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonNWatches.Interfaces;

namespace PokemonNWatches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeldItemAPIController : ControllerBase
    {
        private readonly IHeldItemService _heldItemService;

        public HeldItemAPIController(IHeldItemService heldItemService)
        {
            _heldItemService = heldItemService;
        }

        /// <summary>
        /// Retrieves all Held Items.
        /// </summary>
        /// <returns>List of HeldItem DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeldItemDTO>>> GetAll()
        {
            return Ok(await _heldItemService.ListHeldItems());
        }

        /// <summary>
        /// Retrieves a specific Held Item by ID.
        /// </summary>
        /// <param name="id">The Held Item ID.</param>
        /// <returns>The HeldItem DTO.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HeldItemDTO>> Get(int id)
        {
            var heldItem = await _heldItemService.FindHeldItem(id);
            if (heldItem == null) return NotFound();

            return Ok(heldItem);
        }

        /// <summary>
        /// Creates a new Held Item.
        /// </summary>
        /// <param name="heldItemDto">The HeldItem DTO to create.</param>
        /// <returns>The created HeldItem DTO.</returns>
        [HttpPost]
        public async Task<ActionResult<HeldItemDTO>> Create([FromBody] HeldItemDTO heldItemDto)
        {
            var createdHeldItem = await _heldItemService.CreateHeldItem(heldItemDto);
            return CreatedAtAction(nameof(Get), new { id = createdHeldItem.HeldItemId }, createdHeldItem);
        }

        /// <summary>
        /// Updates an existing Held Item.
        /// </summary>
        /// <param name="id">The Held Item ID.</param>
        /// <param name="heldItemDto">The updated HeldItem DTO.</param>
        /// <returns>No content on success.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HeldItemDTO heldItemDto)
        {
            var success = await _heldItemService.UpdateHeldItem(id, heldItemDto);
            if (!success) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Held Item.
        /// </summary>
        /// <param name="id">The Held Item ID.</param>
        /// <returns>No content on success.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _heldItemService.DeleteHeldItem(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
