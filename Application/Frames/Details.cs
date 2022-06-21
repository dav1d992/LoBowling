using Domain;
using MediatR;
using Persistence;


namespace Application.Frames
{
    public class Details
    {
        public class Query : IRequest<Frame>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Frame>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Frame> Handle(Query request, CancellationToken cancellationToken)
            {
                var frame = await _context.Frames.FindAsync(request.Id);
                return frame;
            }
        }
    }
}