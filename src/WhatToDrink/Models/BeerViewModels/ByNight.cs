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
    public class ByNight
    {
        public Beer Beer { get; set; }
        public IEnumerable<Beer> Beers { get; set; }
        public List<SelectListItem> DayId { get; set; }

        public ByNight(ApplicationDbContext ctx)
        {

            this.DayId = ctx.TypeOfDay
                                  .OrderBy(f => f.Description)
                                  .AsEnumerable()
                                  .Select(li => new SelectListItem
                                  {
                                      Text = li.Description,
                                      Value = li.TypeOfDayId.ToString()
                                  }).ToList();

            this.DayId.Insert(0, new SelectListItem
            {
                Text = "What kind of night do you want?",
                Value = "0"
            });

        }
    }
}