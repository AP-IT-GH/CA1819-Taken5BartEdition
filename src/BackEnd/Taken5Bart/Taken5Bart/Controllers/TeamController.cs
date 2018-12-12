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
    [Route("api/Team")]
    [Produces("application/json")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService teamService;
        public TeamController(ITeamService service)
        {
            teamService = service;
        }

        // GET: api/Team
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(teamService.GetTeams());
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = teamService.GetTeam(id);
            if (result == null)
            {
                return NotFound(-1);
            }
            return Ok(result);
        }

        // GET: api/Team/5/GetScorePosition
        [HttpGet("{id}/GetScorePosition")]
        public IActionResult GetScorePos(int id)
        {
            var t = teamService.GetScorePos(id);
            if (t <0)
            {
                return NotFound(-1);
            }
            return Ok(t);
        }

        //put zou correcter zijn, maar unity kent enkel get en post
        // get: api/Team/2/AddSpeler?spelerID=1
        [HttpGet("{id}/AddSpeler")]
        public IActionResult AddSpeler(int id, int spelerID)
        {
            var result = teamService.SpelerJoin(spelerID, id);
            if (result)
            {
                return Ok(1);
            }
            return Ok(0);
        }

        //put zou correcter zijn, maar unity kent enkel get en post
        // get: api/Team/2/AddSpeler?spelerID=1
        [HttpGet("{id}/ActivePuzzelID")]
        public IActionResult ActivePuzzelID(int id)
        {
            var result = teamService.ActivePuzzelID(id);
            return Ok(result);
        }

        //put zou correcter zijn, maar unity kent enkel get en post
        // get: api/Team/2/AddSpeler?spelerID=1
        [HttpGet("{id}/ActivePuzzel")]
        public IActionResult ActivePuzzel(int id)
        {
            var result = teamService.ActivePuzzel(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(-1);
        }

        [HttpPut("{id}/ActivePuzzel")]
        public IActionResult SetActivePuzzel(int id,bool reset)
        {
            var result = teamService.SetActivePuzzel(id, reset);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(-1);
        }



        // POST: api/Team/id?spelerID=5
        [HttpPost("{id}")]
        public IActionResult Post(int id, int spelerID)
        {
            var result = teamService.SpelerJoin(spelerID, id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("{id}/startpuzzel")]
        public IActionResult PostStartPuzzel(int id)
        {
            var result = teamService.GetStartPuzzel(id);
            if (result != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("{id}/nextpuzzel")]
        public IActionResult PostNextPuzzel(int id)
        {
            var result = teamService.GetNewPuzzel(id);
            if (result != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }


        // PUT: api/Team/5
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
}
