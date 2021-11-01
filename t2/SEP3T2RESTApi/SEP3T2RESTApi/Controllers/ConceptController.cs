using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceptMessageService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEP3T2RESTApi.Data;
using SEP3T2RESTApi.Model;

namespace SEP3T2RESTApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ConceptController : ControllerBase
    {
        private IConceptService ConceptService;

        public ConceptController(IConceptService conceptService)
        {
            ConceptService = conceptService;
        }

        // GET: Concept
        [HttpGet("{id:int}")]
        public async Task<ActionResult<conceptMessage>> GetConceptMessage([FromRoute] int id)
        {
            Console.WriteLine($"{this} received an request {nameof(GetConceptMessage)}");
            conceptMessage conceptMessage = null; 
            try
            {
                  conceptMessage= await ConceptService.FetchConceptMessageAsync(id);
                if (conceptMessage == null)
                {
                    return NotFound("No Concept Was Found");
                }
                return Ok(conceptMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}