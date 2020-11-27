using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StateRegions.Queries
{
    public class ListByMatrix
    {
        public class Query : IRequest<List<StateMonthMatrix>> { }

        public class Handler : IRequestHandler<Query, List<StateMonthMatrix>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<StateMonthMatrix>> Handle(Query request, CancellationToken cancellationToken)
            {
                var stateRegions = await _context.StateRegions.ToListAsync();
                List<StateMonthMatrix> stateMonthMatrices = new List<StateMonthMatrix>();

                foreach(var element in stateRegions)
                {
                    if (stateMonthMatrices != null && stateMonthMatrices.Count > 1 && stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State) != null)
                    {
                        if (element.Month == "January")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).JanuarySales = element.NumberOfSales;
                        }
                        else if (element.Month == "Feburary")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).FebruarySales = element.NumberOfSales;
                        }
                        else if (element.Month == "March")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).MarchSales = element.NumberOfSales;
                        }
                        else if (element.Month == "April")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).AprilSales = element.NumberOfSales;
                        }
                        else if (element.Month == "May")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).JuneSales = element.NumberOfSales;
                        }
                        else if (element.Month == "June")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).JulySales = element.NumberOfSales;
                        }
                        else if (element.Month == "July")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).AugustSales = element.NumberOfSales;
                        }
                        else if (element.Month == "August")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).SeptemberSales = element.NumberOfSales;
                        }
                        else if (element.Month == "September")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).OctoberSales = element.NumberOfSales;
                        }
                        else if (element.Month == "November")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).NovemberSales = element.NumberOfSales;
                        }
                        else if (element.Month == "December")
                        {
                            stateMonthMatrices.FirstOrDefault(x => x.StateName == element.State).DecemberSales = element.NumberOfSales;
                        }
                    }
                    else
                    {
                        StateMonthMatrix stateMonthMatrix = new StateMonthMatrix();
                        stateMonthMatrix.StateName = element.State;

                        if (element.Month == "January")
                        {
                            stateMonthMatrix.JanuarySales = element.NumberOfSales;
                        }
                        else if (element.Month == "Feburary")
                        {
                            stateMonthMatrix.FebruarySales = element.NumberOfSales;
                        }
                        else if (element.Month == "March")
                        {
                            stateMonthMatrix.MarchSales = element.NumberOfSales;
                        }
                        else if (element.Month == "April")
                        {
                            stateMonthMatrix.AprilSales = element.NumberOfSales;
                        }
                        else if (element.Month == "May")
                        {
                            stateMonthMatrix.MaySales = element.NumberOfSales;
                        }
                        else if (element.Month == "June")
                        {
                            stateMonthMatrix.JuneSales = element.NumberOfSales;
                        }
                        else if (element.Month == "July")
                        {
                            stateMonthMatrix.JulySales = element.NumberOfSales;
                        }
                        else if (element.Month == "August")
                        {
                            stateMonthMatrix.AugustSales = element.NumberOfSales;
                        }
                        else if (element.Month == "September")
                        {
                            stateMonthMatrix.SeptemberSales = element.NumberOfSales;
                        }
                        else if (element.Month == "November")
                        {
                            stateMonthMatrix.NovemberSales = element.NumberOfSales;
                        }
                        else if (element.Month == "December")
                        {
                            stateMonthMatrix.DecemberSales = element.NumberOfSales;
                        }

                        stateMonthMatrices.Add(stateMonthMatrix);
                    } 
                }

                return stateMonthMatrices;
            }
        }
    }
}
