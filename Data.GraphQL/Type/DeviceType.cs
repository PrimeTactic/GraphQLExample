using Data.Core.Model;
using Data.Core.Service;
using GraphQL.Types;

namespace Data.GraphQL.Type
{
    public class DeviceType : ObjectGraphType<Device>
    {
        public DeviceType(IUserService userService)
        {
            Field(e => e.Id).Description("The unique identifier of the device.");
            Field(e => e.FriendlyName).Description("The friendly name of the device.");
            Field(e => e.Make).Description("The make of the device.");
            Field(e => e.Model).Description("The model of the device.");
            Field<DeviceStatusEnum>("status", "The status of the device.", resolve: context => context.Source.Status);
            //Field<ListGraphType<UserType>>(
            //    "users",
            //    "The users associated with the device.",
            //    resolve: context => context.Source.AssociatedUserIds.Select(userService.GetUserAsync));
        }
    }
}
