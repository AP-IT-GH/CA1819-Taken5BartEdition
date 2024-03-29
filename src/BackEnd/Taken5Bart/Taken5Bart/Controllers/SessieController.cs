﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.T5B;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.T5B;

namespace Taken5Bart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessieController : ControllerBase
    {
        private ISessieService sessieService;

        public SessieController(ISessieService service)
        {
            sessieService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sessie>> Get()
        {
            return Ok(sessieService.GetSessies());
        }

        // GET: api/Sessie?id=5
        [HttpGet("toList")]
        public ActionResult<TeamListWithCount> GetSessieByCode(string code)
        {
            var result = new TeamListWithCount { Data = sessieService.GetTeamsBySessie(code) };
            if(result.Count < 1)
            {
                return NotFound(-1);
            }
            return Ok(result);
        }

        // GET: api/Sessie/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = sessieService.GetSessie(id);
            if (result == null)
            {
                return NotFound(-1);
            }
            return Ok(result);
        }

        // POST: api/Sessie
        [HttpPost]
        public IActionResult Post([FromBody] Sessie value)
        {
            var result = sessieService.CreateSessie(value);
            if (result.Equals("-1"))
            {
                return BadRequest(-1);
            }
            return Ok(result);
        }

        // PUT: api/Sessie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class TeamListWithCount
    {
        public ICollection<Team> Data
        {
            get; set;
        }
        public int Count { get {
                if (Data == null)
                {
                    return 0;
                }
                else return Data.Count();
            } }
        
    }
}
