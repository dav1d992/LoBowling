using Domain;
using MediatR;
using Persistence;


namespace Application.Users
{
    public class Details
    {
        public class Query : IRequest<User>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, User>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                return user;
            }
        }
    }
}