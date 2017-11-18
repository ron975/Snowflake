﻿using GraphQL.Types;
using Snowflake.Input.Controller;
using Snowflake.Platform;
using Snowflake.Services;
using Snowflake.Support.Remoting.GraphQl.Framework.Attributes;
using Snowflake.Support.Remoting.GraphQl.Framework.Query;
using Snowflake.Support.Remoting.GraphQl.Types.ControllerLayout;
using Snowflake.Support.Remoting.GraphQl.Types.PlatformInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowflake.Support.Remoting.GraphQl.Queries
{
    public class ControllerLayoutQueryBuilder : QueryBuilder
    {
        private IStoneProvider StoneProvider { get; }
        public ControllerLayoutQueryBuilder(IStoneProvider stoneProvider)
        {
            this.StoneProvider = stoneProvider;
        }

        [Field("controllerLayout", "A Stone Controller Layout", typeof(ControllerLayoutType))]
        [Parameter(typeof(string), typeof(StringGraphType), "layoutId", "The Stone Layout ID for this controller")]
        public IControllerLayout GetControllerLayout(string layoutId)
        {
            return this.StoneProvider.Controllers[layoutId];
        }

        [Connection("controllerLayouts", "All Stone Controller Layouts", typeof(ControllerLayoutType))]
        public IEnumerable<IControllerLayout> GetControllerLayouts()
        {
            return this.StoneProvider.Controllers.Values;
        }
    }
}
