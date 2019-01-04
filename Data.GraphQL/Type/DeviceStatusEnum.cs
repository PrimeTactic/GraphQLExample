using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.GraphQL.Type
{
    public class DeviceStatusEnum : EnumerationGraphType
    {
        public DeviceStatusEnum()
        {
            Name = "DeviceStatus";
            AddValue("unknown", "The state of the device unknown.", 0);
            AddValue("registered", "The device has been registered.", 2);
            AddValue("active", "The device is active and has been passively detected.", 4);
            AddValue("verified", "The device has been verified directly and has acknowledged its existence.", 8);
            AddValue("unregistered", "The device has been unregistered.", 16);
        }
    }
}
