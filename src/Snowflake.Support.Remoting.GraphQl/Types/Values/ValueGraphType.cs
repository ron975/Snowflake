﻿using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowflake.Support.Remoting.GraphQl.Types.Values
{
    public class ValueGraphType : UnionGraphType
    {
        public ValueGraphType()
        {
            Name = "Value";
            Description = "A boxed primitive type.";
            Type<IntValueGraphType>();
            Type<BooleanValueGraphType>();
            Type<StringValueGraphType>();
            Type<FloatValueGraphType>();
            Type<EnumIntValueGraphType>();
        }
    }
}
