using Data.Core.Model;
using Data.Core.Service;
using GraphQL.Types;

namespace Data.GraphQL.Type
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IDeviceService deviceService)
        {
            Field(e => e.Id).Description("The unique identifier for the user.");
            Field(e => e.FirstName).Description("The first name of the user.");
            Field(e => e.LastName).Description("The last name of the user.");
            //Field<ListGraphType<DeviceType>>(
            //    "devices", 
            //    "The devices associated with the user.", 
            //    resolve: context => context.Source.AssociatedDeviceIds.Select(deviceService.GetDeviceAsync));
        }
    }
}
