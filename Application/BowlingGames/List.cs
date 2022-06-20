using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BowlingGames
{
    public class List
    {
        public class Query : IRequest<List<BowlingGame>> { }
        public class Handler : IRequestHandler<Query, List<BowlingGame>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<BowlingGame>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bowlingGames = await _context.BowlingGames.ToListAsync();
                return bowlingGames;
            }
        }
    }
}