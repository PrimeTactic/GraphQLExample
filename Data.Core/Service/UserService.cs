using Data.Core.Model;
using Data.Core.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Core.Service
{
    public class UserService : IUserService
    {
        internal static Dictionary<string, User> DataStore;

        public UserService()
        {
            UserService.DataStore = new Dictionary<string, User>();
            this.LoadData();
        }

        public Task<User> GetUserAsync(string id)
        {
            if (!UserService.DataStore.TryGetValue(id, out var result))
            {
                result = new User { Id = "NotFound" };
            }

            return Task.FromResult(result);
        }

        public Task<IEnumerable<User>> GetUsersAsync(PaginationContext paginationContext)
        {
            return Task.FromResult(UserService.DataStore.Values.AsEnumerable());
        }

        private void LoadData()
        {
            var item1 = new User
            {
                Id = "1",
                FirstName = "Jane",
                LastName = "Austen",
                AssociatedDeviceIds = new List<string> { "1" }
            };

            var item2 = new User
            {
                Id = "2",
                FirstName = "Amelia",
                LastName = "Earhart",
                AssociatedDeviceIds = new List<string> { "2" }
            };

            var item3 = new User
            {
                Id = "3",
                FirstName = "Mae",
                LastName = "Jemison",
                AssociatedDeviceIds = new List<string> { "3" }
            };

            var item4 = new User
            {
                Id = "4",
                FirstName = "Maya",
                LastName = "Angelou",
                AssociatedDeviceIds = new List<string> { }
            };

            UserService.DataStore.Add(item1.Id, item1);
            UserService.DataStore.Add(item2.Id, item2);
            UserService.DataStore.Add(item3.Id, item3);
            UserService.DataStore.Add(item4.Id, item4);
        }
    }
}
