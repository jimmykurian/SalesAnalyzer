using Domain;
using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StateRegions
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string State { get; set; }
            public string Month { get; set; }
            public int NumberOfSales { get; set; }
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
                var stateRegion = new StateRegion
                {
                    Id = request.Id,
                    State = request.State,
                    Month = request.Month,
                    NumberOfSales = request.NumberOfSales
                };

                _context.StateRegions.Add(stateRegion);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
