using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[conrtoller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public ProfessorController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

         [HttpGet("{ProfessorID}")]
        public IActionResult Get(int ProfessorID)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{ProfessorID}")]
        public IActionResult Put(int ProfessorID)
        {
            return Ok();
        }

        [HttpDelete("{ProfessorID}")]
        public IActionResult Delete(int ProfessorID)
        {
            return Ok();
        }
    }
}