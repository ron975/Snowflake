﻿using HotChocolate.Types;
using Snowflake.Model.Game;
using Snowflake.Orchestration.Saving;
using Snowflake.Remoting.GraphQL.FrameworkQueries.Mutations.Relay;
using Snowflake.Remoting.GraphQL.Model.Records;
using Snowflake.Remoting.GraphQL.Model.Saving;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowflake.Support.GraphQL.FrameworkQueries.Mutations.Saving
{
    internal sealed class DeleteSaveProfilePayload
        : RelayMutationBase
    {
        public IGame Game { get; set; }
        public ISaveProfile SaveProfile { get; set; }
    }

    internal sealed class DeleteSaveProfilePayloadType
        : ObjectType<DeleteSaveProfilePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteSaveProfilePayload> descriptor)
        {
            descriptor.Name(nameof(DeleteSaveProfilePayload))
                .WithClientMutationId();

            descriptor.Field(g => g.Game)
                .Type<NonNullType<GameType>>();

            descriptor.Field(g => g.SaveProfile)
                .Type<NonNullType<SaveProfileType>>();
        }
    }
}
