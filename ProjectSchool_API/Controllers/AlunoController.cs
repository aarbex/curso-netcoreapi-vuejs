using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        public AlunoController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

         [HttpGet("{AlunoID}")]
        public IActionResult Get(int AlunoID)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{AlunoID}")]
        public IActionResult Put(int AlunoID)
        {
            return Ok();
        }

        [HttpDelete("{AlunoID}")]
        public IActionResult Delete(int AlunoID)
        {
            return Ok();
        }
    }
}