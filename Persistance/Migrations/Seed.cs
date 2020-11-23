using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance.Migrations
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.StateRegions.Any())
            {
                var stateRegions = new List<StateRegion>
                {
                    new StateRegion
                    {
                        State = "Illinois",
                        Month = "January",
                        NumberOfSales = 200
                    },
                    new StateRegion
                    {
                        State = "Illinois",
                        Month = "Feburary",
                        NumberOfSales = 300
                    },
                    new StateRegion
                    {
                        State = "New York",
                        Month = "January",
                        NumberOfSales = 100,
                    },
                    new StateRegion
                    {
                        State = "New York",
                        Month = "Feburary",
                        NumberOfSales = 400
                    }
                };

                context.StateRegions.AddRange(stateRegions);
                context.SaveChanges();
            }
        }
    }
}
