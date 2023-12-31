using System;

namespace NineDigit.Mac.IOKit
{
    /// <summary>
    /// USB communications device descriptor.
    /// </summary>
    public struct USBCommunicationDevice
    {

        /// <summary>
        /// The format used to concatenate the properties <see cref="ProductID"/> and <see cref="VendorID"/> into <see cref="USBDeviceID"/>.
        /// </summary>
        public const string USBDeviceIDFormat = "PID_{0:X}&VID_{1:X}";


        /// <summary>
        /// Gets or sets the caption of the device. 
        /// </summary>
        public string Caption { get; internal set; }

        /// <summary>
        /// Gets or sets the vendor (manufacturer) string of the device.
        /// </summary>
        public string VendorString { get; internal set; }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        public string ProductString { get; internal set; }

        /// <summary>
        /// Gets or sets the devices product ID.
        /// </summary>
        public int ProductID { get; internal set; }

        /// <summary>
        /// Gets or sets the devices vendor ID.
        /// </summary>
        public int VendorID { get; internal set; }

        /// <summary>
        /// Gets or sets the concatenated USBDevice ID (PID_4242&VID_2121).
        /// </summary>
        public string USBDeviceID
            => String.Format("PID_{0:X}&VID_{1:X}", ProductID, VendorID);

        /// <summary>
        /// Gets or sets the COM file name.
        /// </summary>
        public string ComName { get; internal set; }
    }
}