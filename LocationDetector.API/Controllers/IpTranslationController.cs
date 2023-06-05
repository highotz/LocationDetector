using LocationDetector.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocationDetector.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IpTranslationController : ControllerBase
{
    private string _uploadFileType;
    private string _responseFileType;
    private readonly IConfiguration _configuration;
    private IIpTranslationRequestProcessor _ipTranslationProcessor;

    public IpTranslationController(IConfiguration configuration, IIpTranslationRequestProcessor ipTranslationRequestProcessor)
    {
        _configuration = configuration;
        _ipTranslationProcessor = ipTranslationRequestProcessor;
        _uploadFileType = _configuration.GetValue<string>("TranslationControllerConfiguration:Upload").ToLower();
        _responseFileType = _configuration.GetValue<string>("TranslationControllerConfiguration:Response").ToLower();
    }

    [HttpPost(Name = "UploadClientIpListFile")]
    public async Task<IActionResult> IpTranslation(IFormFile file)
    {
        if(ModelState.IsValid)
        {
            if (file.FileName.EndsWith(_uploadFileType))
            {
                try
                {
                    _ipTranslationProcessor.IpTranslation(file);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest($"Invalid file type. Only {_uploadFileType} files are allowed.");
            }
        }

        return BadRequest(ModelState);
    }
}
