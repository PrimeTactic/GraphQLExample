using Data.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Core.Utility;

namespace Data.Core.Service
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string id);

        Task<IEnumerable<User>> GetUsersAsync(PaginationContext paginationContext);
    }
}
