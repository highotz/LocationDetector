using LocationDetector.Core.Interfaces;
using LocationDetector.Core.Models;
using Microsoft.AspNetCore.Http;

namespace LocationDetector.Core.Processors
{
    internal class IpTranslationRequestProcessor : IIpTranslationRequestProcessor
    {
        public List<IpTranslationResponse> IpTranslation(IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using var reader = new StreamReader(file.OpenReadStream());
                var conteudo = reader.ReadToEndAsync();
            }
            else
            {
                
            }

            return null;
        }
    }
}
