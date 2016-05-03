using System.Collections.Generic;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace
namespace NLog.Targets
// ReSharper restore CheckNamespace
{
    public class MessageBuildersFacade : MessageBuilder
    {
        private readonly Dictionary<RfcNumber,MessageBuilder> builders;

        /// <summary>The Syslog protocol RFC to be followed</summary> 
        public RfcNumber Rfc { get; set; }

        /// <summary>RFC 3164 related fields</summary> 
        public Rfc3164 Rfc3164 { get; set; }

        /// <summary>RFC 5424 related fields</summary> 
        public Rfc5424 Rfc5424 { get; set; }

        /// <summary>Initializes a new instance of the MessageBuildersFacade class</summary>
        public MessageBuildersFacade()
        {
            Rfc = RfcNumber.Rfc5424;
            Rfc3164 = new Rfc3164();
            Rfc5424 = new Rfc5424();
            builders = new Dictionary<RfcNumber, MessageBuilder>
            {
                { RfcNumber.Rfc3164, Rfc3164 },
                { RfcNumber.Rfc5424, Rfc5424 }
            };
        }

        /// <summary>Builds the Syslog message according to the RFC to follow</summary>
        /// <param name="logEvent">The NLog.LogEventInfo</param>
        /// <param name="pri">The Syslog PRI part</param>
        /// <param name="logEntry">The entry to be logged</param>
        /// <returns>Bytes containing the Syslog message</returns>
        public override IEnumerable<byte> BuildMessage(LogEventInfo logEvent, string pri, string logEntry)
        {
            var rfcToFollow = builders[Rfc];
            return rfcToFollow.BuildMessage(logEvent, pri, logEntry);
        }
    }
}