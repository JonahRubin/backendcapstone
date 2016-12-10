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
    public class ChooseAll    {
        public Beer Beer { get; set; }
        public IEnumerable<Beer> Beers { get; set;}
        public Season Season { get; set; }
        public List<SelectListItem> SeasonId { get; set; }
        public List<SelectListItem> FeelingId { get; set; }
        public List<SelectListItem> DayId { get; set; }

        public ChooseAll(ApplicationDbContext ctx)
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

            this.FeelingId = ctx.Feeling
                                    .OrderBy(f => f.Description)
                                    .AsEnumerable()
                                    .Select(li => new SelectListItem
                                    {
                                        Text = li.Description,
                                        Value = li.FeelingId.ToString()
                                    }).ToList();

            this.FeelingId.Insert(0, new SelectListItem
            {
                Text = "How are you feeling?",
                Value = "0"
            });

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