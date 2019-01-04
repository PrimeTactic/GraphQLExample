using System;
using Data.Core.Model;
using Data.Core.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Core.Service
{
    public class DeviceService : IDeviceService
    {
        internal static Dictionary<string, Device> DataStore;

        private int count = 100;

        private readonly IDeviceEventService deviceEventService;

        public DeviceService(IDeviceEventService deviceEventService)
        {
            this.deviceEventService = deviceEventService;
            DeviceService.DataStore = new Dictionary<string, Device>();
            this.LoadData();
        }

        public async Task<Device> ActiveAsync(string id)
        {
            var status = DeviceStatus.Active;
            var device = await this.GetDeviceAsync(id).ConfigureAwait(false);
            device.Status = status;

            var deviceEvent = new DeviceEvent()
            {
                DeviceId = device.Id,
                Name = device.FriendlyName,
                Status = status,
                Timestamp = DateTimeOffset.UtcNow
            };
            this.deviceEventService.AddEvent(deviceEvent);

            return device;
        }

        public async Task<Device> UnregisterDeviceAsync(string id)
        {
            var status = DeviceStatus.Unregistered;
            var device = await this.GetDeviceAsync(id).ConfigureAwait(false);
            device.Status = status;

            var deviceEvent = new DeviceEvent()
            {
                DeviceId = device.Id,
                Name = device.FriendlyName,
                Status = status,
                Timestamp = DateTimeOffset.UtcNow
            };
            this.deviceEventService.AddEvent(deviceEvent);

            return device;
        }

        public Task<Device> RegisterDeviceAsync(Device device)
        {
            if (device != null)
            {
                var status = DeviceStatus.Registered;
                device.Id = count.ToString();
                count++;
                device.Status = status;
                DeviceService.DataStore.Add(device.Id, device);

                var deviceEvent = new DeviceEvent()
                {
                    DeviceId = device.Id,
                    Name = device.FriendlyName,
                    Status = status,
                    Timestamp = DateTimeOffset.UtcNow
                };
                this.deviceEventService.AddEvent(deviceEvent);
            }

            return Task.FromResult(device);
        }

        public Task<Device> GetDeviceAsync(string id)
        {
            if (!DeviceService.DataStore.TryGetValue(id, out var result))
            {
                result = new Device { Id = "NotFound" };
            }
            
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Device>> GetDevicesAsync(PaginationContext paginationContext)
        {
            return Task.FromResult(DeviceService.DataStore.Values.AsEnumerable());
        }

        public async Task<Device> VerifyAsync(string id)
        {
            var status = DeviceStatus.Verified;
            var device = await this.GetDeviceAsync(id).ConfigureAwait(false);
            device.Status = status;

            var deviceEvent = new DeviceEvent()
            {
                DeviceId = device.Id,
                Name = device.FriendlyName,
                Status = status,
                Timestamp = DateTimeOffset.UtcNow
            };
            this.deviceEventService.AddEvent(deviceEvent);

            return device;
        }

        private void LoadData()
        {
            var item1 = new Device
            {
                Id = "1",
                FriendlyName = "Laptop1",
                Make = "Microsoft",
                Model = "SurfaceBook",
                AssociatedUserIds = new List<string> { "1" }
            };

            var item2 = new Device
            {
                Id = "2",
                FriendlyName = "Desktop2",
                Make = "Microsoft",
                Model = "SurfaceStudio",
                AssociatedUserIds = new List<string> { "2" }
            };

            var item3 = new Device
            {
                Id = "3",
                FriendlyName = "Laptop3",
                Make = "Dell",
                Model = "Inspiron17",
                AssociatedUserIds = new List<string> { "3" }
            };

            DeviceService.DataStore.Add(item1.Id, item1);
            DeviceService.DataStore.Add(item2.Id, item2);
            DeviceService.DataStore.Add(item3.Id, item3);
        }
    }
}
