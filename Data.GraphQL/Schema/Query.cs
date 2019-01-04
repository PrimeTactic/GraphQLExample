using Data.Core.Service;
using Data.GraphQL.Type;
using GraphQL.Types;

namespace Data.GraphQL.Schema
{
    public class Query : ObjectGraphType
    {
        public Query(IDeviceService deviceService, IUserService userService)
        {
            Name = "Query";
            this.RegisterDeviceQueries(deviceService);
            this.RegisterUserQueries(userService);
        }

        public void RegisterDeviceQueries(IDeviceService deviceService)
        {
            // Get device by id
            var arg = new QueryArgument(typeof(StringGraphType))
            {
                Name = "Id",
                Description = "The device id.",
            };

            Field<DeviceType>(
                "device",
                "Get a device by id.",
                new QueryArguments(arg),
                context => deviceService.GetDeviceAsync(context.GetArgument<string>("id")));

            // Get device list
            Field<ListGraphType<DeviceType>>(
                "devices", 
                "Get device list.", 
                null,
                context => deviceService.GetDevicesAsync(null));
        }

        public void RegisterUserQueries(IUserService userService)
        {
            // Get user by id
            var arg = new QueryArgument(typeof(StringGraphType))
            {
                Name = "Id",
                Description = "The user id.",
            };

            Field<UserType>(
                "user",
                "Get a user by id.",
                new QueryArguments(arg),
                context => userService.GetUserAsync(context.GetArgument<string>("id")));

            // Get user list
            Field<ListGraphType<UserType>>(
                "users", 
                "Get user list.", 
                null,
                context => userService.GetUsersAsync(null));
        }
    }
}
