﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Input.Device;
using Snowflake.Utility;

namespace Snowflake.Input.Controller.Mapped
{
    public class MappedControllerElementStore
    {

        private ISimpleKeyValueStore backingStore;

        public MappedControllerElementStore(string fileName)
        {
            this.backingStore = new SqliteKeyValueStore(fileName);
        }

        public IMappedControllerElementCollection this[string deviceId, string controllerId, string profileName = "default"]
        {
            get { return this.GetMappedElements(deviceId, controllerId, profileName); }
            set { this.SetMappedElements(deviceId, controllerId, profileName, value); }
        }
        public IMappedControllerElementCollection GetMappedElements(string deviceId, string controllerId, string profileName = "default")
        {
            return null;
        }

        public void SetMappedElements(string deviceId, string controllerId, 
            string profileName, IMappedControllerElementCollection controllerElements)
        {
            
        }

        public void SetMappedElements(string deviceId, string controllerId, IMappedControllerElementCollection controllerElements)
        {
            this.SetMappedElements(deviceId, controllerId, "default", controllerElements);
        }
    }
}
