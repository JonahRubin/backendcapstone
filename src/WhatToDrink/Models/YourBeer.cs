using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToDrink.Models;
using WhatToDrink.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WhatToDrink.Models
{
    public class YourBeer
    {
        [Key]
        public int YourBeerId { get; set; }
        public Beer Beer { get; set; }
        public int BeerId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
