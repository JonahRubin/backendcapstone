using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhatToDrink.Models;

namespace WhatToDrink.Data
{

    public class DbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                var beerSeasons = new Season[]
             {
                new Season {

                      Name = "Year-round"

                  },


                  new Season {

                      Name = "Spring"

                  },


                  new Season {

                      Name = "Summer"

                  },

                  new Season {

                      Name = "Fall"

                  },

            new Season {

                      Name = "Winter"

                  },

               };
                foreach (Season i in beerSeasons)

                {

                    context.Season.Add(i);

                }

                context.SaveChanges();






                var beerStyles = new Style[]
             {

                new Style {

                      Name = "Fruit beers"

                  },


                  new Style {

                      Name = "Ales"

                  },


                  new Style {

                      Name = "Pale ales"

                  },

                  new Style {

                      Name = "Sours"

                  },

            new Style {

                      Name = "Porters/Stouts"

                  },

                   };
                foreach (Style i in beerStyles)

                {

                    context.Style.Add(i);

                }

                context.SaveChanges();


                var beerFeelings = new Feeling[]
             {

                new Feeling {

                      Description = "Light"

                  },


                  new Feeling {

                      Description = "Normal"

                  },


                  new Feeling {

                      Description = "Bitter"

                  },

                  new Feeling {

                      Description = "Weird"

                  },

            new Feeling {

                      Description = "Dark"

                  },

                 };
                foreach (Feeling i in beerFeelings)

                {

                    context.Feeling.Add(i);

                }

                context.SaveChanges();


                var beerDays = new TypeOfDay[]
             {
                new TypeOfDay {

                      Description = "School night"

                  },


                  new TypeOfDay {

                      Description = "Extended happy hour"

                  },


                  new TypeOfDay {

                      Description = "It's the weekend"

                  },

                  new TypeOfDay {

                      Description = "Epic"

                  },

            new TypeOfDay {

                      Description = "Bender"

                  },

                 };
                foreach (TypeOfDay i in beerDays)

                {

                    context.TypeOfDay.Add(i);

                }

                context.SaveChanges();


                var beerABVs = new ABV[]
             {
                new ABV {

                      Name = "4% and under"

                  },


                  new ABV {

                      Name = "4% to 6%"

                  },


                  new ABV {

                      Name = "6% to 8%"

                  },

                  new ABV {

                      Name = "8% to 10%"

                  },

            new ABV {

                      Name = "More than 10%"

                  },

                  };
                foreach (ABV i in beerABVs)

                {

                    context.ABV.Add(i);

                }

                context.SaveChanges();

                var beers = new Beer[]
            {
                new Beer {

                      Name = "Stiegl Radler",
                      Brewery = "Stieglbrauerei zu Salzburg",
                      StyleId = 1,
                      ABVId = 1,
                      SeasonId = 1,

                  },


            new Beer {

                      Name = "Schöfferhofer Grapefruit Weizen-Mix",
                  Brewery = "Binding Brauerei",
                  StyleId = 1,
                  ABVId = 1,
                  SeasonId = 1,


                  },
            new Beer {

                      Name = "Divergent",
                  Brewery = "Rivertown Brewing Co.",
                  StyleId = 4,
                  ABVId = 1,
                  SeasonId = 1,


                  },
            new Beer {

                      Name = "Mango Even Keel",
                  Brewery = "Ballast Point",
                  StyleId = 3,
                  ABVId = 1,
                  SeasonId = 1,


                  },
        new Beer {

                      Name = "Jibe Session IPA",
                  Brewery = "Green Flash",
                  StyleId = 3,
                  ABVId = 1,
                  SeasonId = 1,


                  },
        new Beer {

                      Name = "Nomader Weisse",
                  Brewery = "Evil Twin Brewing",
                  StyleId = 4,
                  ABVId = 1,
                  SeasonId = 3,


                  },
        new Beer {

                      Name = "Shindig Shandy",
                  Brewery = "Blackstone Brewing Co.",
                  StyleId = 1,
                  ABVId = 1,
                  SeasonId = 3,


                  },
    new Beer {

                      Name = "Oarsman",
                  Brewery = "Bell's Brewery",
                  StyleId = 4,
                  ABVId = 1,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Suspicion",
                  Brewery = "Bearded Iris",
                  StyleId = 2,
                  ABVId = 1,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Piety",
                  Brewery = "NOLA",
                  StyleId = 4,
                  ABVId = 1,
                  SeasonId = 2,


                  },
    new Beer {

                      Name = "London Pride",
                  Brewery = "Fuller, Smith & Turner",
                  StyleId = 2,
                  ABVId = 2,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Anchor Porter",
                  Brewery = "Anchor Brewing Co.",
                  StyleId = 5,
                  ABVId = 2,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "312 Urban Wheat Ale",
                  Brewery = "Goose Island",
                  StyleId = 2,
                  ABVId = 2,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Gotta Get Up To Get Down",
                  Brewery = "Wiseacre Brewing",
                  StyleId = 5,
                  ABVId = 2,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Narragansett Summer Ale",
                  Brewery = "Narragansett Brewing Co.",
                  StyleId = 2,
                  ABVId = 2,
                  SeasonId = 3,


                  },
    new Beer {

                      Name = "Cranberry Ginger Shandy",
                  Brewery = "Jacob Leinenkugel Brewing Co.",
                  StyleId = 1,
                  ABVId = 2,
                  SeasonId = 5,


                  },
    new Beer {

                      Name = "Raspberry Jam",
                  Brewery = "Tallgrass Brewing Co.",
                  StyleId = 4,
                  ABVId = 2,
                  SeasonId = 2,


                  },
    new Beer {

                      Name = "Cranberry Pumpkinfest",
                  Brewery = "Terrapin",
                  StyleId = 2,
                  ABVId = 2,
                  SeasonId = 4,


                  },
    new Beer {

                      Name = "Buffalo Sweat Oatmeal Cream Stout",
                  Brewery = "Tallgrass Brewing Co.",
                  StyleId = 5,
                  ABVId = 2,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Grunion Pale Ale",
                  Brewery = "Ballast Point",
                  StyleId = 3,
                  ABVId = 2,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Milk Stout Nitro",
                  Brewery = "Left Hand",
                  StyleId = 5,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Grand Cru",
                  Brewery = "Rodenbach",
                  StyleId = 4,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Bed of Nails Brown",
                  Brewery = "Hi-Wire",
                  StyleId = 2,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Porter",
                  Brewery = "Founders Brewing Co.",
                  StyleId = 5,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Duchess de Bourgogne",
                  Brewery = "Brouwerij Verhaeghe",
                  StyleId = 4,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Two Hearted Ale",
                  Brewery = "Bell's Brewery",
                  StyleId = 3,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "60 Minute IPA",
                  Brewery = "Dogfish Head",
                  StyleId = 3,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Evil Octopus",
                  Brewery = "Mayday Brewing",
                  StyleId = 2,
                  ABVId = 3,
                  SeasonId = 1,


                  },
    new Beer {

                      Name = "Old Sour Cherry Porter",
                  Brewery = "Rivertown Brewing Co.",
                  StyleId = 4,
                  ABVId = 3,
                  SeasonId = 3,


                  },
    new Beer {

                      Name = "Hipster Repellant IPA",
                  Brewery = "Falls City Brewing Co.",
                  StyleId = 3,
                  ABVId = 3,
                  SeasonId = 1,


                  },
new Beer {

                      Name = "Kasteel Rouge",
                  Brewery = "Brouwerij Van Honsebrouck",
                  StyleId = 1,
                  ABVId = 4,
                  SeasonId = 1,


                  },
new Beer {

                      Name = "Lolita",
                  Brewery = "Goose Island",
                  StyleId = 4,
                  ABVId = 4,
                  SeasonId = 5,


                  },
new Beer {

                      Name = "Pumking",
                  Brewery = "Southern Tier",
                  StyleId = 2,
                  ABVId = 4,
                  SeasonId = 4,


                  },
new Beer {

                      Name = "Sumatra Mountain Brown",
                  Brewery = "Founders Brewing Co.",
                  StyleId = 2,
                  ABVId = 4,
                  SeasonId = 3,


                  },
new Beer {
                      Name = "reDANKulous",
                  Brewery = "Founders Brewing Co.",
                  StyleId = 3,
                  ABVId = 4,
                  SeasonId = 3,


                  },
new Beer {

                      Name = "Curmudgeon Old Ale",
                  Brewery = "Falls City Brewing Co.",
                  StyleId = 2,
                  ABVId = 4,
                  SeasonId = 2,


                  },
new Beer {

                      Name = "Imperial Stout",
                  Brewery = "Lagunitas Brewing Co.",
                  StyleId = 5,
                  ABVId = 4,
                  SeasonId = 3,


                  },
new Beer {

                      Name = "Petrus Aged Red",
                  Brewery = "De Brabandere",
                  StyleId = 4,
                  ABVId = 4,
                  SeasonId = 1,


                  },
new Beer {

                      Name = "Wake-n-Bake Coffee Oatmeal Stout",
                  Brewery = "Terrapin Brewing Co.",
                  StyleId = 5,
                  ABVId = 4,
                  SeasonId = 5,


                  },
new Beer {

                  Name = "Kentucky Old Fashioned Barrel Ale",
                  Brewery = "Alltech's Lexington Brewing and Distilling Co.",
                  StyleId = 2,
                  ABVId = 4,
                  SeasonId = 1,


                  },
new Beer {

                      Name = "Backwoods Bastard",
                  Brewery = "Founders Brewing Co.",
                  StyleId = 2,
                  ABVId = 5,
                  SeasonId = 4,


                  },
new Beer {

                      Name = "Wake Up Dead Nitro",
                  Brewery = "Left Hand",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 5,


                  }, new Beer {

                      Name = "Dragon’s Milk",
                  Brewery = "New Holland Brewing Co.",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 1,


                  }, new Beer {

                      Name = "Kentucky Breakfast Stout",
                  Brewery = "Founders Brewing Co.",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 2,


                  }, new Beer {

                      Name = "Unobtanium",
                  Brewery = "Straight to Ale",
                  StyleId = 2,
                  ABVId = 5,
                  SeasonId = 5,


                  }, new Beer {

                      Name = "Imperial Biscotti Break",
                  Brewery = "Evil Twin Brewing",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 1,


                  }, new Beer {

                      Name = "Ten FIDY",
                  Brewery = "Oskar Blues",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 4,


                  }, new Beer {

                      Name = "RuinTen Triple IPA",
                  Brewery = "Stone Brewing Co.",
                  StyleId = 3,
                  ABVId = 5,
                  SeasonId = 3,


                  }, new Beer {

                      Name = "Christmas BOMB!",
                  Brewery = "Prairie Artisan Ales",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 5,


                  }, new Beer {

                      Name = "Bourbon County Brand Stout",
                  Brewery = "Goose Island",
                  StyleId = 5,
                  ABVId = 5,
                  SeasonId = 4,


                  },


  };
                foreach (Beer i in beers)

                {

                    context.Beer.Add(i);

                }

                context.SaveChanges();



            }
        }

    }
}

    

