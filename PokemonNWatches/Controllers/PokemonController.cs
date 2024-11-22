using Microsoft.AspNetCore.Mvc;
using PokemonNWatches.Interfaces;
using PokemonNWatches.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonNWatches.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // Action to list all Pokémon
        public async Task<IActionResult> Index()
        {
            var pokemons = await _pokemonService.ListPokemons();

            // Convert to ViewModel
            var viewModel = pokemons.Select(p => new PokemonViewModel
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
            });

            return View(viewModel); // Pass data to the Index.cshtml view
        }

        // Action to view Pokémon details
        public async Task<IActionResult> Details(int id)
        {
            var pokemon = await _pokemonService.FindPokemon(id);
            if (pokemon == null) return NotFound();

            var viewModel = new PokemonViewModel
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

            return View(viewModel); // Pass data to the Details.cshtml view
        }

        // Action to display a form to create a Pokémon
        public IActionResult Create()
        {
            return View(); // Renders a form (Create.cshtml)
        }

        // Action to handle form submission for creating a Pokémon
        [HttpPost]
        public async Task<IActionResult> Create(PokemonViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var pokemonDTO = new PokemonDTO
            {
                PokemonName = viewModel.PokemonName,
                PokemonRole = viewModel.PokemonRole,
                PokemonStyle = viewModel.PokemonStyle,
                PokemonHP = viewModel.PokemonHP,
                PokemonAttack = viewModel.PokemonAttack,
                PokemonDefense = viewModel.PokemonDefense,
                PokemonSpAttack = viewModel.PokemonSpAttack,
                PokemonSpDefense = viewModel.PokemonSpDefense,
                PokemonCDR = viewModel.PokemonCDR
            };

            await _pokemonService.CreatePokemon(pokemonDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
