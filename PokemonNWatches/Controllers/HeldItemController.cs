using Microsoft.AspNetCore.Mvc;
using PokemonNWatches.Interfaces;
using PokemonNWatches.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonNWatches.Controllers
{
    public class HeldItemController : Controller
    {
        private readonly IHeldItemService _heldItemService;

        public HeldItemController(IHeldItemService heldItemService)
        {
            _heldItemService = heldItemService;
        }

        // List all Held Items
        public async Task<IActionResult> Index()
        {
            var heldItems = await _heldItemService.ListHeldItems();

            var viewModel = heldItems.Select(h => new HeldItemViewModel
            {
                HeldItemId = h.HeldItemId,
                HeldItemName = h.HeldItemName,
                HeldItemHP = h.HeldItemHP,
                HeldItemAttack = h.HeldItemAttack,
                HeldItemDefense = h.HeldItemDefense,
                HeldItemSpAttack = h.HeldItemSpAttack,
                HeldItemSpDefense = h.HeldItemSpDefense,
                HeldItemCDR = h.HeldItemCDR
            });

            return View(viewModel);
        }
    }
}
