using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using Data.Core.Model;

namespace Data.Core.Service
{
    public class DeviceEventService : IDeviceEventService
    {
        private readonly ISubject<DeviceEvent> eventStream = new ReplaySubject<DeviceEvent>(1);

        public DeviceEventService()
        {
            this.AllEvents = new ConcurrentStack<DeviceEvent>();
        }

        public ConcurrentStack<DeviceEvent> AllEvents { get; }
    

        public void AddError(Exception exception)
        {
            this.eventStream.OnError(exception);
        }

        public DeviceEvent AddEvent(DeviceEvent deviceEvent)
        {
            this.AllEvents.Push(deviceEvent);
            this.eventStream.OnNext(deviceEvent);
            return deviceEvent;
        }

        public IObservable<DeviceEvent> EventStream()
        {
            return this.eventStream.AsObservable();
        }
    }
}
