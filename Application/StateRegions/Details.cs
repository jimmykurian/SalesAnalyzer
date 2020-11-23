using Domain;
using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StateRegions
{
    public class Details
    {
        public class Query : IRequest<StateRegion>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, StateRegion>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<StateRegion> Handle(Query request, CancellationToken cancellationToken)
            {
                var stateRegion = await _context.StateRegions.FindAsync(request.Id);

                return stateRegion;
            }
        }
    }
}
