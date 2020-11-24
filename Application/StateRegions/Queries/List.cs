using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StateRegions.Queries
{
    public class List
    {
        public class Query : IRequest<List<StateRegion>> { }

        public class Handler : IRequestHandler<Query, List<StateRegion>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<StateRegion>> Handle(Query request, CancellationToken cancellationToken)
            {
                var stateRegions = await _context.StateRegions.ToListAsync();

                return stateRegions;
            }
        }
    }
}
