using Data.Core.Model;
using System;
using System.Collections.Concurrent;

namespace Data.Core.Service
{
    public interface IDeviceEventService
    {
        ConcurrentStack<DeviceEvent> AllEvents { get; }

        void AddError(Exception exception);

        DeviceEvent AddEvent(DeviceEvent deviceEvent);

        IObservable<DeviceEvent> EventStream();
    }
}
