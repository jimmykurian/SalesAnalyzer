using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.States.Queries
{
    public class List
    {
        public class Query : IRequest<List<State>> { }

        public class Handler : IRequestHandler<Query, List<State>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<State>> Handle(Query request, CancellationToken cancellationToken)
            {
                var states = await _context.States.ToListAsync();

                return states;
            }
        }
    }
}
