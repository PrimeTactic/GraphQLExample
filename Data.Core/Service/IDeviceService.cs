using Data.Core.Model;
using Data.Core.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Core.Service
{
    public interface IDeviceService
    {
        Task<Device> GetDeviceAsync(string id);

        Task<IEnumerable<Device>> GetDevicesAsync(PaginationContext paginationContext);

        Task<Device> RegisterDeviceAsync(Device device);

        Task<Device> UnregisterDeviceAsync(string id);

        Task<Device> ActiveAsync(string id);

        Task<Device> VerifyAsync(string id);
    }
}
