using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StateRegions.Commands
{
    public class Create
    {
        public class Command : IRequest
        {
            public List<StateRegion> StateRegions { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var successCounts = 0;
                foreach (var element in request.StateRegions)
                {
                    var stateRegion = new StateRegion
                    {
                        Id = new Guid(),
                        State = element.State,
                        Month = element.Month,
                        NumberOfSales = element.NumberOfSales
                    };

                    _context.StateRegions.Add(stateRegion);
                    var success = await _context.SaveChangesAsync() > 0;
                    
                    if (success)
                    {
                        successCounts++;
                    }
                }


                if (successCounts > 0) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
