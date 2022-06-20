using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;


namespace Application.BowlingGames
{
    public class Details
    {
        public class Query : IRequest<BowlingGame>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, BowlingGame>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<BowlingGame> Handle(Query request, CancellationToken cancellationToken)
            {
                var bowlingGame = await _context.BowlingGames.FindAsync(request.Id);
                return bowlingGame;
            }
        }
    }
}