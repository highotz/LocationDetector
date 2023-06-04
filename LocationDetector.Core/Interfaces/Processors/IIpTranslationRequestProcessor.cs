using LocationDetector.Core.Models;
using Microsoft.AspNetCore.Http;

namespace LocationDetector.Core.Interfaces
{
    public interface IIpTranslationRequestProcessor
    {
        List<IpTranslationResponse> IpTranslation(IFormFile file);
    }
}
