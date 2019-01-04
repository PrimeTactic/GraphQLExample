using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Core.Model;
using Data.Core.Service;
using Data.GraphQL.Type;

namespace Data.GraphQL.Schema
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(IDeviceService deviceService)
        {
            Name = "Mutation";

            var arg1 = new QueryArgument<NonNullGraphType<RegisterDeviceInputType>>
            {
                Name = "device",
                Description = "The device to register.",
            };
            Field<DeviceType>(
                "registerDevice",
                "Register a new device.",
                new QueryArguments(arg1),
                context => deviceService.RegisterDeviceAsync(context.GetArgument<Device>("device")));

            var arg2 = new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = "id",
                Description = "The device id.",
            };
            Field<DeviceType>(
                "activePing",
                "Set the device status to active.",
                new QueryArguments(arg2),
                context => deviceService.ActiveAsync(context.GetArgument<string>("id")));

            var arg3 = new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = "id",
                Description = "The device id.",
            };
            Field<DeviceType>(
                "verifyDevice",
                "Set the device status to verify.",
                new QueryArguments(arg3),
                context => deviceService.VerifyAsync(context.GetArgument<string>("id")));

            var arg4 = new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = "id",
                Description = "The device id.",
            };
            Field<DeviceType>(
                "unregisterDevice",
                "Unregister an existing device.",
                new QueryArguments(arg4),
                context => deviceService.UnregisterDeviceAsync(context.GetArgument<string>("id")));
        }
    }
}
