using LocationDetector.Core.Helpers;
using LocationDetector.Core.Models;
using LocationDetector.Domain.Interfaces;
using LocationDetector.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace LocationDetector.Persistence.Repositories
{
    public class IPTranslationService : IIPTranslationService
    {

        public List<IpTranslationResponse> IpTranslate(List<IpTranslationRequest> translationRequests)
        {
            byte[] fileBytes;
            string filePath = "DataFiles/IPs.csv";
#if DEBUG
            filePath = "bin/Debug/net7.0/DataFiles/IPs.csv";
#endif

            var reader = new StreamReader(filePath);

            List<LocalizationIp> localizationIps = FilesHelper.ReadCsvFile<LocalizationIp>(reader);

            List<IpTranslationResponse> translationResponses = (
                from request in translationRequests
                join localization in localizationIps on request.ip equals localization.ip
                select new IpTranslationResponse
                {
                    timestamp = request.timestamp,
                    id = request.id,
                    ip = request.ip,
                    latitude = localization.latitude,
                    longitude = localization.longitude,
                    country = localization.country,
                    state = localization.state,
                    city = localization.city
                }).ToList();

            return translationResponses;


        }
    }
}
