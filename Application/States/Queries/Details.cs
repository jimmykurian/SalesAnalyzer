using Domain;
using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.States.Queries
{
    public class Details
    {
        public class Query : IRequest<State>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, State>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<State> Handle(Query request, CancellationToken cancellationToken)
            {
                var state = await _context.States.FindAsync(request.Id);

                return state;
            }
        }
    }
}
