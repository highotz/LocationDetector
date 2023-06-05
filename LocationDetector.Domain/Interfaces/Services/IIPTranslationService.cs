using LocationDetector.Core.Models;

namespace LocationDetector.Domain.Interfaces
{
    public interface IIPTranslationService
    {
        List<IpTranslationResponse> IpTranslate(List<IpTranslationRequest> ipList);
    }
}
