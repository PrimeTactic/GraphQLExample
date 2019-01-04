using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Core.Model
{
    [Flags]
    public enum DeviceStatus
    {
        Unknown = 0,
        Registered = 2,
        Active = 4,
        Verified = 8,
        Unregistered = 16,
    }
}
