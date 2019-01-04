namespace Data.Core.Model
{
    using System.Collections.Generic;

    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<string> AssociatedDeviceIds { get; set; }
    }
}
