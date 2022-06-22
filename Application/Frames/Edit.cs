using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Frames
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int BowlingGameId { get; set; }
            public int FrameNumber { get; set; }
            public int FirstRoll { get; set; }
            public int SecondRoll { get; set; }
            public int ThirdRoll { get; set; }


            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var frame = await _context.Frames.FindAsync(request.Id);
                    if (frame == null)
                    {
                        throw new Exception("Could not find frame");
                    }

                    frame.UserId = request.UserId;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Unit.Value;

                    throw new Exception("Problem saving changes");
                }
            }
        }
    }
}