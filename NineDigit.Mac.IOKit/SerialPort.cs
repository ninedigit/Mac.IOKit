using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NineDigit.Mac.IOKit
{
	/// <summary>
	/// Serial port utilities using IOKit.
	/// </summary>
	public static class SerialPort
	{
#if DEBUG
		private static TraceVerbosity verbosity = TraceVerbosity.All;
#else
	private static TraceVerbosity verbosity = TraceVerbosity.ErrorAndWarning;
#endif
		/// <summary>
		/// Gets or sets the trace verbosity.
		/// </summary>
		public static TraceVerbosity Verbosity
		{
			get => verbosity;
			set => verbosity = value;
		}

		/// <summary>
		/// Returns a list of available communication devices.
		/// </summary>
		/// <returns>A list of <see cref="USBCommunicationDevice"/> instances.</returns>
		public static List<USBCommunicationDevice> GetUSBCommunicationDevices()
		{
			var result = new List<USBCommunicationDevice>();
			using var serialPortIterator = IOKitFramework.FindModems();

			if (serialPortIterator == null)
				return result;
			
			var modemService = serialPortIterator.Next();

			while (modemService != null)
			{
				using (modemService)
				{
					var modemPath = IOKitFramework.GetModemPath(modemService);
					if (string.IsNullOrEmpty(modemPath))
					{
						if (verbosity > TraceVerbosity.Silent)
						{
							Trace.TraceError("Could not get path for modem.\n");
						}
					}
					else
					{
						using var device = IOKitFramework.GetUSBDevice(modemService);
						
						if (device != null)
						{
							var vendorString = device.GetCFPropertyString(IOKitFramework.kUSBVendorString);
							var productString =
								device.GetCFPropertyString(IOKitFramework.kUSBProductString);
							var productID = device.GetCFPropertyInt(IOKitFramework.kUSBProductID);
							var vendorID = device.GetCFPropertyInt(IOKitFramework.kUSBVendorID);

							if (productID > 0 && vendorID > 0)
							{
								var deviceDescriptor = new USBCommunicationDevice
								{
									ComName = modemPath,
									VendorString = vendorString,
									ProductString = productString,
									VendorID = vendorID,
									ProductID = productID,
									Caption = $"{vendorString} {productString}"
								};

								result.Add(deviceDescriptor);
							}
						}
					}
				}

				modemService = serialPortIterator.Next();
			}

			return result;
		}
	}
}