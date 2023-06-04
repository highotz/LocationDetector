using Microsoft.AspNetCore.Mvc;

namespace LocationDetector.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IpTranslationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public IpTranslationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost(Name = "UploadClientIpListFile")]
    public async Task<IActionResult> Post(IFormFile file)
    {    

        return Ok(_configuration.GetValue<string>("TranslationControllerConfiguration:Upload"));


        // Check if a file was sent in the request
        if (Request.Form.Files.Count == 0)
        {
            return BadRequest("No files have been uploaded.");
        }

        // Check the file type (CSV or JSON)
        if (file.FileName.EndsWith(".csv"))
        {
            // Process CSV File
            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            return Ok("CSV file successfully processed.");
        }
        else if (file.FileName.EndsWith(".json"))
        {
            // Process JSON file

            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            return Ok("JSON file successfully processed.");
        }
        else
        {
            return BadRequest("Invalid file type. Only CSV or JSON files are allowed.");
        }
    }
}
