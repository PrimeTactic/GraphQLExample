using Data.Core.Model;
using Data.Core.Service;
using Data.GraphQL.Type;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Data.GraphQL.Schema
{
    public class Subscription : ObjectGraphType
    {
        private readonly IDeviceEventService deviceEventService;

        public Subscription(IDeviceEventService deviceEventService)
        {
            this.deviceEventService = deviceEventService;
            Name = "Subscription";
            this.RegisterDeviceSubscription();
        }

        public void RegisterDeviceSubscription()
        {
            var arg = new QueryArgument<ListGraphType<DeviceStatusEnum>>
            {
                Name = "statuses"
            };

            AddField(new EventStreamFieldType
            {
                Name = "deviceEvent",
                Arguments = new QueryArguments(arg),
                Type = typeof(DeviceEventType),
                Resolver = new FuncFieldResolver<DeviceEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<DeviceEvent>(Subscribe)
            });
        }

        private DeviceEvent ResolveEvent(ResolveFieldContext context)
        {
            var deviceEvent = context.Source as DeviceEvent;
            return deviceEvent;
        }

        private IObservable<DeviceEvent> Subscribe(ResolveEventStreamContext context)
        {
            var statusList = context.GetArgument<IList<DeviceStatus>>("statuses", new List<DeviceStatus>());

            if (statusList.Count > 0)
            {
                DeviceStatus statuses = 0;

                foreach (var status in statusList)
                {
                    statuses = statuses | status;
                }

                return this.deviceEventService.EventStream().Where(e => (e.Status & statuses) == e.Status);
            }
            else
            {
                return this.deviceEventService.EventStream();
            }
        }
    }
}
