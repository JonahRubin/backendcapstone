using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToDrink.Models;
using WhatToDrink.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace WhatToDrink.Models.BeerViewModels
{
    public class BySeason
    {
        public Beer Beer { get; set; }
        public IEnumerable<Beer> Beers { get; set; }
        public Season Season { get; set; }
        public List<SelectListItem> SeasonId { get; set; }
      
        public BySeason(ApplicationDbContext ctx)
        {

            this.SeasonId = ctx.Season
                                    .OrderBy(l => l.Name)
                                    .AsEnumerable()
                                    .Select(li => new SelectListItem
                                    {
                                        Text = li.Name,
                                        Value = li.SeasonId.ToString()
                                    }).ToList();

            this.SeasonId.Insert(0, new SelectListItem
            {
                Text = "Choose a season",
                Value = "0"
            });

            

           

        }
    }
}