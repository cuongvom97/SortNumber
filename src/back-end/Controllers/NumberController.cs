using back_end.services;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly INumber _number;
        public NumberController(INumber number)
        {
            _number = number;
        }
        [HttpPost("sort")]
        public IActionResult SortNumber(string number)
        {
            try
            {
                var result = _number.Sort(number);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}