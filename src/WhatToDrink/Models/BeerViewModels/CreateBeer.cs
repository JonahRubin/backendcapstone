using System.Collections.Generic;
using System.Linq;
using WhatToDrink.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhatToDrink.Models.BeerViewModels
{
    public class CreateBeer
    {
        public Beer Beer { get; set; }

        public Style Style { get; set; }
        public List<SelectListItem> StyleId { get; set; }
        public List<SelectListItem> ABVId { get; set; }
        public ABV ABV { get; set; }

        public CreateBeer(ApplicationDbContext ctx)
        {
            var context = ctx;
            this.StyleId = ctx.Style
                                 .OrderBy(l => l.Name)
                                 .AsEnumerable()
                                 .Select(li => new SelectListItem
                                 {
                                     Text = li.Name,
                                     Value = li.StyleId.ToString()
                                 }).ToList();

            this.StyleId.Insert(0, new SelectListItem
            {
                Text = "Choose a style",
                Value = "0"
            });

            this.ABVId = ctx.ABV
                                    .OrderBy(f => f.Name)
                                    .AsEnumerable()
                                    .Select(li => new SelectListItem
                                    {
                                        Text = li.Name,
                                        Value = li.ABVId.ToString()
                                    }).ToList();

            this.ABVId.Insert(0, new SelectListItem
            {
                Text = "Choose an ABV",
                Value = "0"
            });
        }
    }
}