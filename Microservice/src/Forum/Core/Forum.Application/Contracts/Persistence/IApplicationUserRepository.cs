using Common.Services.Repositories;
using Forum.Domain.Entities;

namespace Forum.Application.Contracts.Persistence
{
    public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser>
    {
    }
}
