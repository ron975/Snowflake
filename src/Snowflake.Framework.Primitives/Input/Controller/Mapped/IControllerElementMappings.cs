﻿using Snowflake.Input.Device;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake.Input.Controller.Mapped
{
    /// <summary>
    /// Represents a collection of mapped elements.
    /// </summary>
    public interface IControllerElementMappings : IEnumerable<MappedControllerElement>
    {
        /// <summary>
        /// Gets the device id of the real device
        /// </summary>
        InputDriverType DriverType { get; }

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        string DeviceName { get; }

        /// <summary>
        /// Gets the vendor ID of the device this mapping was created for.
        /// </summary>
        int VendorID { get; }

        /// <summary>
        /// Gets the controller id of the virtual controller layout
        /// </summary>
        ControllerId ControllerID { get; }

        /// <summary>
        /// Gets or sets the device element mapped to the given layout element,
        /// if the layout element exists for this particular layout.
        /// 
        /// If it does not exist, then the setter does nothing, and
        /// the device element returns <see cref="ControllerElement.NoElement"/>
        /// </summary>
        /// <param name="layoutElement">The layout element</param>
        /// <returns>The device element that is mapped to the given layout element.</returns>
        DeviceCapability this[ControllerElement layoutElement] { get; set; }
    }
}
