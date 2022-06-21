using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Frames
{
    public class List
    {
        public class Query : IRequest<List<Frame>> { }
        public class Handler : IRequestHandler<Query, List<Frame>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Frame>> Handle(Query request, CancellationToken cancellationToken)
            {
                var frames = await _context.Frames.ToListAsync();
                return frames;
            }
        }
    }
}