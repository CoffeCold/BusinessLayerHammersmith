using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeroBusinessLayer.Services;
using HeroBusinessLayer.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using HeroBusinessLayer.Infrastructure;
using Graph = Microsoft.Graph;
using Microsoft.Extensions.Options;


namespace HeroBusinessLayer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly ILogger<HeroesController> _logger;
        private IHeroesService _heroesService;
        private readonly ITokenAcquisition tokenAcquisition;
        private readonly WebOptions webOptions;
        public HeroesController(ILogger<HeroesController> logger, IHeroesService heroesService, IOptions<WebOptions> webOptionValue)
        {
            _logger = logger;
            _heroesService = heroesService;
            webOptions = webOptionValue.Value; 
        }

        //[AuthorizeForScopes(Scopes = new[] { GraphScopes.UserReadBasicAll })]
        //[Authorize(Policy = AuthorizationPolicies.AssignmentToUserReaderRoleRequired)]
        [HttpGet]
        public IActionResult Get(int? id, string name)
        {
            //Graph::GraphServiceClient graphClient = GetGraphServiceClient(new[] { GraphScopes.UserReadBasicAll });

            ////var users = await graphClient.Users.Request().GetAsync();

            //var users = graphClient.Users.Request().GetAsync();

            //_logger.LogInformation("Get heroes called, users found {0}", users);


            if (!String.IsNullOrEmpty(name))
            {
                _logger.LogInformation("GetById heroes called for name {0}", name);

                Heroes hero = _heroesService.GetOneByName(name);
                if (hero != null) { return Ok(hero); } else { return NotFound(); }
            }
            if (id != null)
            {
                _logger.LogInformation("GetById heroes called for id {0}", id);
                Heroes hero = _heroesService.GetOneById(id);
                if (hero != null) { return Ok(hero); } else { return NotFound(); }
            }
            _logger.LogInformation("Get heroes called ");
            IEnumerable<Heroes> allheroes = _heroesService.GetAll();
            if (allheroes != null)
            {
                return Ok(allheroes);
            }
            return NotFound();
        }

        //private Graph::GraphServiceClient GetGraphServiceClient(string[] scopes)
        //{
        //    return GraphServiceClientFactory.GetAuthenticatedGraphClient(async () =>
        //    {
        //        string result = await tokenAcquisition.GetAccessTokenForUserAsync(scopes);
        //        return result;
        //    }, webOptions.GraphApiUrl);
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            _logger.LogInformation("GetById heroes called for id {0}", id);
            Heroes hero = _heroesService.GetOneById(id);
            if (hero != null)
            {
                return Ok(hero);
            }
            return NotFound();

        }


        [HttpPost]
        public async Task<ActionResult<Heroes>> CreateHero(Heroes hero)
        {
            _logger.LogInformation("Post heroes called for id {0}", hero.Id);
            await _heroesService.AddOne(hero);
            if (hero != null)
            {
                return CreatedAtAction(nameof(GetById), new { id = hero.Id }, hero);
            }
            else
            {
                // internal server error
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Heroes>> DeleteHero(int? id)
        {
            _logger.LogInformation("Delete heroes called for id {0}", id);
            Heroes hero =  await _heroesService.DeleteOneByID(id);
            if (hero != null)
            {
                return hero;
            }
            else
            {               
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult<Heroes>> UpdateHero(Heroes hero)
        {
            _logger.LogInformation("Put heroes called for id {0}", hero.Id);
            await _heroesService.UpdateOne(hero); 
            if (hero != null)
            {
                return hero;
            }
            else
            {
                return NotFound();
            }        
        }



    }
}
