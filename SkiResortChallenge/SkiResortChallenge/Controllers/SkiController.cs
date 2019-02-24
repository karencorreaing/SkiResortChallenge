using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkiChallenge.Utils;
using SkiResortChallenge.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkiResortChallenge.Controllers
{
    [Route("api/[controller]")]
    public class SkiController : Controller
    {
        // GET: api/ski
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            SkiCalc calc = new SkiCalc();
            SkiResponse response = calc.calc();
            return Ok(response);
        }

       
    }
}
