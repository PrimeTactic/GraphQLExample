using System;

namespace Data.Core.Model
{
    public class DeviceEvent
    {
        public DeviceEvent()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        public string DeviceId { get; set; }

        public string Name { get; set; }

        public DeviceStatus Status { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
