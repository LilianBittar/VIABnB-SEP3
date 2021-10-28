using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEP3T2RESTApi.Data;
using SEP3T2RESTApi.Model;

namespace SEP3T2RESTApi.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class ConceptController : ControllerBase
    {
        private IConceptService ConceptService;
        private ConceptMessage conceptMessage;

        public ConceptController(IConceptService conceptService)
        {
            ConceptService = conceptService;
        }

        // GET: Concept
        [HttpGet("{ID:int}")]
        public async Task<ActionResult<ConceptMessage>> GetConceptUpdate([FromRoute] int ID)
        {
            try
            {
                  conceptMessage= await ConceptService.FetchConceptMessageAsync(ID);

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