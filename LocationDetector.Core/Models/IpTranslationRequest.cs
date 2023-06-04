using System.ComponentModel.DataAnnotations;

namespace LocationDetector.Core.Models
{
    public class IpTranslationRequest
    {
        public TimestampAttribute timestamp { get; set; }
        public Guid id { get; set; }
        public string ip { get; set; }
    }
}
