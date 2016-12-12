using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WhatToDrink.Models;
using WhatToDrink.Models.AccountViewModels;
using WhatToDrink.Services;
using WhatToDrink.Data;
using WhatToDrink.Models.BeerViewModels;
using Microsoft.EntityFrameworkCore;

namespace WhatToDrink.Controllers
{


    public class BeerController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;

        private ApplicationDbContext context;

        public BeerController(ApplicationDbContext ctx, UserManager<ApplicationUser> user)
        {
            _userManager = user;
            context = ctx;
        }

        [HttpGet]
        public IActionResult ChooseAll()
        {
            ChooseAll model = new ChooseAll(context);
            return View(model);
        }

        [HttpGet]
        public IActionResult ByFeeling()
        {
            ByFeeling model = new ByFeeling(context);
            return View(model);
        }

        [HttpGet]
        public IActionResult BySeason()
        {
            BySeason model = new BySeason(context);
            return View(model);
        }

        [HttpGet]
        public IActionResult ByNight()
        {
            ByNight model = new ByNight(context);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetBeersBySeason([FromRoute]int id)
        {
            var beersBySeason = context.Beer.OrderBy(s => s.Name.ToUpper()).Where(s => s.SeasonId == id).ToList();
            return Json(beersBySeason);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ChooseAll model = new ChooseAll(context);
            model.Beers = context.Beer.OrderBy(s => s.Name.ToUpper());

            

            return View(model);

        }

        [HttpPost]
        public IActionResult GetBeersByFeelings([FromRoute]int id)
        {
            var beersByFeelings = context.Beer.OrderBy(s => s.Name.ToUpper()).Where(s => s.StyleId == id).ToList();
            return Json(beersByFeelings);
        }


        [HttpPost]
        public IActionResult GetBeersByDay([FromRoute]int id)
        {
            var beersByDay = context.Beer.OrderBy(s => s.Name.ToUpper()).Where(s => s.ABVId == id).ToList();
            return Json(beersByDay);
        }


        [HttpPost("/Beer/GetBeersByAll/{id1}/{id2}/{id3}")]
        public IActionResult GetBeersByAll([FromRoute]int id1, [FromRoute] int id2, [FromRoute] int id3)
        {
            var beersByAll = context.Beer.OrderBy(s => s.Name.ToUpper()).Where(s => s.ABVId == id3 && s.StyleId == id2 && s.SeasonId == id1).ToList();
            return Json(beersByAll);
        }

        [HttpGet]
        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BeerDetail model = new BeerDetail(context);

            model.Beer = await context.Beer
                    .SingleOrDefaultAsync(b => b.BeerId == id);

            if (model.Beer == null)
            {
                return NotFound();
            }


            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Beer beer)
        {     
            CreateBeer model = new CreateBeer(context);
            return View(model);
        }
    }

}