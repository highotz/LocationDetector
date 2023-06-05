using LocationDetector.Core.Helpers;
using LocationDetector.Core.Models;
using LocationDetector.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LocationDetector.Core.Processors
{
    public class IpTranslationRequestProcessor : IIpTranslationRequestProcessor
    {
        private IIPTranslationService _ipTranslationService;

        public IpTranslationRequestProcessor(IIPTranslationService ipTranslationService)
        {
            _ipTranslationService = ipTranslationService;
        }
        public List<IpTranslationResponse> IpTranslation(IFormFile file)
        {

            List<IpTranslationRequest> ipTranslationRequests;
            List<IpTranslationResponse> ipTranslationResponses;

            if (file.FileName.EndsWith(".csv"))
            {
                using var reader = new StreamReader(file.OpenReadStream());
                ipTranslationRequests = FilesHelper.ReadCsvFile<IpTranslationRequest>(reader);
                ipTranslationResponses = _ipTranslationService.IpTranslate(ipTranslationRequests);
            }
            else
            {
                using var reader = new StreamReader(file.OpenReadStream());
                ipTranslationRequests = FilesHelper.ReadJsonlFile<IpTranslationRequest>(reader);
            }

            return null;
        }
    }
}
