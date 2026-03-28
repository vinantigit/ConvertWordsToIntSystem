using Microsoft.AspNetCore.Mvc;
using WordsToIntConverter.Core;

namespace ConvertWordsToIntWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IConvertWordsToInt _convertWordsToInt;

        public ConverterController(IConvertWordsToInt convertWordsToInt)
        {
            _convertWordsToInt = convertWordsToInt;
        }

        [HttpGet("convert")]
        public ActionResult<int> Convert([FromQuery] string words)
        {
            if (string.IsNullOrWhiteSpace(words))
                return BadRequest("Input cannot be empty.");

            try
            {
                return Ok(_convertWordsToInt.ConvertWordsToIntMethod(words)); 
            }
            catch
            {
                // _logger.LogError(ex, "Conversion failed");
                return BadRequest("Invalid word sequence.");
            }
        }
    }
}
