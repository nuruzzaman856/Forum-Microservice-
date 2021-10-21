using NZForum.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NZForum.Client.ApiServices
{
    public interface IForumApiService
    {
        Task<IEnumerable<Forum>> GetForums();
        Task<Forum> GetForum(string id);
        Task<Forum> CreateForum(Forum Forum);
        Task<Forum> UpdateForum(Forum Forum);
        Task DeleteForum(int id);
        //Task<UserInfoViewModel> GetUserInfo();
    }
}
