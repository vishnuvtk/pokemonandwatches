using Microsoft.AspNetCore.Mvc;
using PokemonNWatches.Interfaces;
using PokemonNWatches.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonNWatches.Controllers
{
    public class BuildController : Controller
    {
        private readonly IBuildService _buildService;

        public BuildController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        // List all Builds
        public async Task<IActionResult> Index()
        {
            var builds = await _buildService.ListBuilds();

            var viewModel = builds.Select(b => new BuildViewModel
            {
                BuildId = b.BuildId,
                PokemonUpdatedHP = b.PokemonUpdatedHP,
                PokemonUpdatedAttack = b.PokemonUpdatedAttack,
                PokemonUpdatedDefense = b.PokemonUpdatedDefense,
                PokemonUpdatedSpAttack = b.PokemonUpdatedSpAttack,
                PokemonUpdatedSpDefense = b.PokemonUpdatedSpDefense,
                PokemonUpdatedCDR = b.PokemonUpdatedCDR,
                PokemonId = b.PokemonId,
                PokemonName = b.Pokemon?.PokemonName
            });

            return View(viewModel);
        }

        // View Build Details
        public async Task<IActionResult> Details(int id)
        {
            var build = await _buildService.FindBuilds(id);
            if (build == null) return NotFound();

            var viewModel = new BuildViewModel
            {
                BuildId = build.BuildId,
                PokemonUpdatedHP = build.PokemonUpdatedHP,
                PokemonUpdatedAttack = build.PokemonUpdatedAttack,
                PokemonUpdatedDefense = build.PokemonUpdatedDefense,
                PokemonUpdatedSpAttack = build.PokemonUpdatedSpAttack,
                PokemonUpdatedSpDefense = build.PokemonUpdatedSpDefense,
                PokemonUpdatedCDR = build.PokemonUpdatedCDR,
                PokemonId = build.PokemonId,
                PokemonName = build.Pokemon?.PokemonName
            };

            return View(viewModel);
        }
    }
}
