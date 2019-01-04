using Data.Core.Model;
using GraphQL.Types;

namespace Data.GraphQL.Type
{
    public class DeviceEventType : ObjectGraphType<DeviceEvent>
    {
        public DeviceEventType()
        {
            Field(e => e.Id);
            Field(e => e.DeviceId);
            Field(e => e.Name);
            Field<DeviceStatusEnum>("status", resolve: context => context.Source.Status);
            Field(e => e.Timestamp);
        }
    }
}
