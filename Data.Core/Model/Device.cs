namespace Data.Core.Model
{
    using System.Collections.Generic;

    public class Device
    {
        public string Id { get; set; }

        public string FriendlyName { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public DeviceStatus Status { get; set; }

        public ICollection<string> AssociatedUserIds { get; set; }
    }
}
