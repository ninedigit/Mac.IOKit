namespace NineDigit.Mac.IOKit
{
    /// <summary>
    /// Verbosity enumeration.
    /// </summary>
    public enum TraceVerbosity
    {
        /// <summary>
        /// No messages will be sent to trace listeners.
        /// </summary>
        Silent,

        /// <summary>
        /// Only error messages will be sent to trace listeners.
        /// </summary>
        Error,

        /// <summary>
        /// Only error and warning messages will be sent to trace listeners.
        /// </summary>
        ErrorAndWarning,

        /// <summary>
        /// All messages will be sent to trace listeners.
        /// </summary>
        All
    }
}