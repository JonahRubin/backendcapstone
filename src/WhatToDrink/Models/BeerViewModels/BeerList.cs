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
    public class BeerList
    {
        public List<Beer> YourBeers { get; set; }

        public BeerList (ApplicationDbContext ctx) 
        {
        var context = ctx;
        }

    }
}