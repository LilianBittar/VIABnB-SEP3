using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEP3T2RESTApi.Data;

namespace SEP3T2RESTApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptController : ControllerBase
    {
        private IConceptService ConceptService;

        public ConceptController(IConceptService conceptService)
        {
            ConceptService = conceptService;
        }

        // GET: Concept
        [HttpGet("ID:int")]
        public async Task<ActionResult> GetButtonUpdate([FromRoute] int ID)
        {
            try
            {
                ConceptService.ConceptActivation(ID);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}