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
    public class BeerDetail
    {
        public Beer Beer { get; set; }
        public Style Style { get; set; }
        public ABV ABV { get; set; }
        public Season Season { get; set; }

        public BeerDetail(ApplicationDbContext ctx)
        {
            var context = ctx;
        }
    }
}