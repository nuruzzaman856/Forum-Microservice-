using Common.Services.Repositories;
using Forum.Application.Contracts.Persistence;
using Forum.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("forumConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostReplyRepository, PostReplyRepository>();

            return services;
        }
    }
}
