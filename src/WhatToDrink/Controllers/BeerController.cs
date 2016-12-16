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

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
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

            model.Style = await context.Style
                    .SingleOrDefaultAsync(s => s.StyleId == model.Beer.StyleId);

            model.ABV = await context.ABV
                    .SingleOrDefaultAsync(a => a.ABVId == model.Beer.ABVId);

            model.Season = await context.Season
                    .SingleOrDefaultAsync(s => s.SeasonId == model.Beer.SeasonId);

            if (model.Beer == null)
            {
                return NotFound();
            }


            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListDetail([FromRoute]int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BeerDetail model = new BeerDetail(context);

            model.Beer = await context.Beer
                    .SingleOrDefaultAsync(b => b.BeerId == id);

            model.Style = await context.Style
                    .SingleOrDefaultAsync(s => s.StyleId == model.Beer.StyleId);

            model.ABV = await context.ABV
                    .SingleOrDefaultAsync(a => a.ABVId == model.Beer.ABVId);

            model.Season = await context.Season
                    .SingleOrDefaultAsync(s => s.SeasonId == model.Beer.SeasonId);

            if (model.Beer == null)
            {
                return NotFound();
            }


            return View(model);
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            CreateBeer model = new CreateBeer(context);
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Beer beer)
        {
            CreateBeer model = new CreateBeer(context);

            context.Add(beer);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

      

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToList([FromRoute] int id)
        {
            var user = await GetCurrentUserAsync();
            YourBeer yourBeer = new YourBeer();
            yourBeer.User = user;
            yourBeer.BeerId = id;
            context.YourBeer.Add(yourBeer);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [Authorize]
        public async Task<IActionResult> RemoveFromList([FromRoute] int id)
        {
            var user = await GetCurrentUserAsync();
            var yourBeer = await context.YourBeer.Where(yb => yb.User == user && yb.BeerId == id).SingleOrDefaultAsync();
            context.YourBeer.Remove(yourBeer);
            await context.SaveChangesAsync();
            return RedirectToAction("ListOfBeers");

        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListOfBeers()
        {
            var user = await GetCurrentUserAsync();
            BeerList model = new BeerList(context);
            List<YourBeer> yourBeers = context.YourBeer.Where(li => li.User == user).ToList();

            model.YourBeers = new List<Beer>();
            for (var i = 0; i < yourBeers.Count(); i++)
            {
                model.YourBeers.Add(context.Beer.Where(b => b.BeerId == yourBeers[i].BeerId).SingleOrDefault());
            }

            return View(model);
        }


    }
}