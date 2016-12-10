using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatToDrink.Models
{
    public class Beer 
    {
        [Key]
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Brewery { get; set; }
        public int StyleId { get; set; }
        public Style Style { get; set; }
        public int ABVId { get; set; }
        public ABV ABV { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public TypeOfDay TypeOfDay { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        public string ImgUrl { get; set; }




    }
}
