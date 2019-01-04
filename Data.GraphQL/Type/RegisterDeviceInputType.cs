using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace Data.GraphQL.Type
{
    public class RegisterDeviceInputType : InputObjectGraphType
    {
        public RegisterDeviceInputType()
        {
            Name = "RegisterDeviceInput";
            Field<NonNullGraphType<StringGraphType>>("friendlyName");
            Field<NonNullGraphType<StringGraphType>>("make");
            Field<NonNullGraphType<StringGraphType>>("model");
        }
    }
}
