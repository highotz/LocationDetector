using Microsoft.AspNetCore.Mvc;

namespace LocationDetector.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IpTranslationController : ControllerBase
{

    public IpTranslationController()
    {
    }

    [HttpPost(Name = "UploadClientIpListFile")]
    public async Task<IActionResult> Post()
    {
        // Check if a file was sent in the request
        if (Request.Form.Files.Count == 0)
        {
            return BadRequest("No files have been uploaded.");
        }

        var arquivo = Request.Form.Files[0];

        // Check the file type (CSV or JSON)
        if (arquivo.FileName.EndsWith(".csv"))
        {
            // Process CSV File
            using var reader = new StreamReader(arquivo.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            return Ok("Arquivo CSV processado com sucesso.");
        }
        else if (arquivo.FileName.EndsWith(".json"))
        {
            // Process JSON file

            using var reader = new StreamReader(arquivo.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            return Ok("JSON file successfully processed.");
        }
        else
        {
            return BadRequest("Invalid file type. Only CSV or JSON files are allowed.");
        }
    }
}
