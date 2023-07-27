// See https://aka.ms/new-console-template for more information

using NineDigit.Mac.IOKit;

SerialPort.Verbosity = TraceVerbosity.All;

var devices = SerialPort.GetUSBCommunicationDevices();
Console.WriteLine($"Found {devices.Count} connected devices.");

foreach (var device in devices)
{
    Console.WriteLine($"Product: {device.ProductString} ({device.ProductID})");
    Console.WriteLine($"Vendor: {device.VendorString} ({device.VendorID})");
}