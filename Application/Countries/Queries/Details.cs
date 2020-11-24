using Domain;
using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Countries.Queries
{
    public class Details
    {
        public class Query : IRequest<Country>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Country>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Country> Handle(Query request, CancellationToken cancellationToken)
            {
                var state = await _context.Countries.FindAsync(request.Id);

                return state;
            }
        }
    }
}
