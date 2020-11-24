using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StateRegions.Commands
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string State { get; set; }
            public string Month { get; set; }
            public int? NumberOfSales { get; set; }
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
                var stateRegion = await _context.StateRegions.FindAsync(request.Id);

                if (stateRegion == null)
                    throw new Exception("Could not find state region record");

                stateRegion.State = request.State ?? stateRegion.State;
                stateRegion.Month = request.Month ?? stateRegion.Month;
                stateRegion.NumberOfSales = request.NumberOfSales ?? stateRegion.NumberOfSales;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
                        
            }
        }
    }
}
