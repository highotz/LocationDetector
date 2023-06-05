namespace LocationDetector.Core.Models
{
    public class IpTranslationResponse : IpTranslationRequest
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}
