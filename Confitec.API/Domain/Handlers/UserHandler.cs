using Confitec.API.Context;
using Confitec.API.Domain.Contracts;
using Confitec.API.Domain.Handlers.Base;
using Confitec.API.Models;

namespace Confitec.API.Domain.Handlers
{
    public class UserHandler : GenericHandler<User>, IUserHandler
    {
        public UserHandler(AppDbContext ctx) : base(ctx)
        {
        }

    }
}
