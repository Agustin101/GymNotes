using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExercisesService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(JsonSerializer.Serialize(new { message = "It works!" }));
        }
    }
}