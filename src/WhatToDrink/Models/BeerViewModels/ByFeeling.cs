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
    public class ByFeeling
    {
        public Beer Beer { get; set; }
        public IEnumerable<Beer> Beers { get; set; }
        public List<SelectListItem> FeelingId { get; set; }

        public ByFeeling(ApplicationDbContext ctx)
        {

           
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

        

        }
    }
}