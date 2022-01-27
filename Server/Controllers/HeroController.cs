using Blazor_Heroes.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Heroes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        static List<Comic> Comics = new List<Comic>
        {
            new Comic {Id=1, Name="DC"},
            new Comic{Id=2, Name="Marvel"}
        };

        List<SuperHero> Heroes = new List<SuperHero>
        {
            new SuperHero {Id=1 ,Name="Spiderman", Comic=Comics[1] },
            new SuperHero {Id=2 ,Name="Batman", Comic=Comics[0] }

        };
        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            return Ok(Comics);
        }

        public async Task<IActionResult> GetHeroes()
        {
            return Ok(Heroes);
        }

        [HttpGet("{id}")]      
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var hero = Heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)                
                return NotFound("Wasn't found");         
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> PostHero(SuperHero hero)
        {
            Heroes.Add(hero);
            return Ok(Heroes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var hero = Heroes[id];
            if (hero == null)
                return BadRequest();
            Heroes.Remove(hero);
            return Ok();
        }

    }
}
