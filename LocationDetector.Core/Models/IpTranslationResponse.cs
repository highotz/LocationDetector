using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDetector.Core.Models
{
    internal class IpTranslationResponse : IpTranslationRequest
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}
