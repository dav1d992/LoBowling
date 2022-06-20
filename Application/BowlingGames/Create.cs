using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.BowlingGames
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string PlayerName { get; set; }
            public int Score { get; set; }
            public Frame[] Frames { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var bowlinggame = new BowlingGame
                {
                    Id = request.Id,
                    PlayerName = request.PlayerName,
                    Score = request.Score,
                    Frames = request.Frames,
                };

                _context.BowlingGames.Add(bowlinggame);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}