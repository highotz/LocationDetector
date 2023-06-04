using LocationDetector.Core.Helpers;
using LocationDetector.Core.Interfaces;
using LocationDetector.Core.Models;
using Microsoft.AspNetCore.Http;

namespace LocationDetector.Core.Processors
{
    internal class IpTranslationRequestProcessor : IIpTranslationRequestProcessor
    {
        public List<IpTranslationResponse> IpTranslation(IFormFile file)
        {

            List<IpTranslationRequest> ipTranslationRequests;

            if (file.FileName.EndsWith(".csv"))
            {
                ipTranslationRequests = FilesHelper.ReadCsvFile<IpTranslationRequest>(file);
            }
            else
            {
                ipTranslationRequests = FilesHelper.ReadJsonlFile<IpTranslationRequest>(file);
            }

            return null;
        }
    }
}
