using LocationDetector.Core.Helpers;
using LocationDetector.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net.Mime;

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

                    byte[] fileBytes;
                    string contentType;


                    if (_responseFileType == "csv")
                    {
                        fileBytes = FilesHelper.GenerateCsv(_ipTranslationProcessor.IpTranslation(file));
                        contentType = "text/csv";
                    }
                    else
                    {
                        fileBytes = FilesHelper.GenerateJsonl(_ipTranslationProcessor.IpTranslation(file));
                        contentType = "application/x-jsonlines";
                    }

                    return new FileContentResult(fileBytes, contentType)
                    {
                        FileDownloadName = $"ipLocations.{_responseFileType}"
                    };

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while returning the file: {ex.Message}");
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
