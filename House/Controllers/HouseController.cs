using House.Core.Dtos;
using House.Core.ServiceInterface;
using House.Data;
using House.Models.House;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace House.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseServices _houseService;

        public HouseController
            (
            HouseDbContext context,
            IHouseServices houseService
            )
        {
            _context = context;
            _houseService = houseService;
        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.House
                .Select(x => new HouseListItem
                {
                    Id = x.Id,
                    TotalArea = x.TotalArea,
                    Address = x.Address,
                    Details = x.Details,
                    Price = x.Price,
                    Rooms = x.Rooms,
                    Year = x.Year
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                TotalArea = model.TotalArea,
                Address = model.Address,
                Details = model.Details,
                Price = model.Price,
                Rooms = model.Rooms,
                Year = model.Year

            };

            var result = await _houseService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);
            if (house == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var model = new HouseViewModel();

            model.Id = house.Id;
            model.TotalArea = house.TotalArea;
            model.Address = house.Address;
            model.Details = house.Details;
            model.Price = house.Price;
            model.Rooms = house.Rooms;
            model.Year = house.Year;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                TotalArea = model.TotalArea,
                Address = model.Address,
                Details = model.Details,
                Price = model.Price,
                Rooms = model.Rooms,
                Year = model.Year
                
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

    }
}
