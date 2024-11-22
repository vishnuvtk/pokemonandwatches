using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonNWatches.Interfaces;

namespace PokemonNWatches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildAPIController : ControllerBase
    {
        private readonly IBuildService _buildService;

        public BuildAPIController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        /// <summary>
        /// Retrieves all Builds.
        /// </summary>
        /// <returns>List of Build DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildDTO>>> GetAll()
        {
            return Ok(await _buildService.ListBuilds());
        }

        /// <summary>
        /// Retrieves a specific Build by ID.
        /// </summary>
        /// <param name="id">The Build ID.</param>
        /// <returns>The Build DTO.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildDTO>> Get(int id)
        {
            var build = await _buildService.FindBuilds(id);
            if (build == null) return NotFound();

            return Ok(build);
        }

        /// <summary>
        /// Creates a new Build.
        /// </summary>
        /// <param name="buildDto">The Build DTO to create.</param>
        /// <returns>Success response.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BuildDTO buildDto)
        {
            await _buildService.CreateBuilds(buildDto);
            return Ok();
        }

        /// <summary>
        /// Updates an existing Build.
        /// </summary>
        /// <param name="buildDto">The updated Build DTO.</param>
        /// <returns>No content on success.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BuildDTO buildDto)
        {
            buildDto.BuildId = id;
            var success = await _buildService.UpdateBuilds(buildDto);
            if (!success) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Build.
        /// </summary>
        /// <param name="id">The Build ID.</param>
        /// <returns>No content on success.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _buildService.DeleteBuilds(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
