using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private Character mock = new Character { Name = "Mock" };
        private List<Character> mocks = new List<Character>
        {
            new Character{ Id=0, Name="Mock List"},
            new Character{ Id=1, Name="Second Mock"},
        };

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(mocks);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> Get(int id)
        {
            var result = mocks.Find(c => c.Id == id);
            // var result = (
            //     from mock in mocks
            //     where mock.Id == id
            //     select mock)
            //     .FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<List<Character>> Post(Character newChar)
        {
            mocks.Add(newChar);
            return Ok(mocks);
        }
    }
}
