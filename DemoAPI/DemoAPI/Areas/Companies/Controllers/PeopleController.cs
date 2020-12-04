using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.Companies.Managers;
using Domain.Areas.People.Models;

namespace DemoAPI.Areas.Companies.Controllers
{
    [ApiController]
    [Route("Companies/{companyId:long}/[controller]/")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly PeopleManager manager;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
            manager = new PeopleManager();
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<PersonDetailsModel>> Index(long companyId, string searchTerm = null)
        {
            var search = new PersonSearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(companyId, search);

            return Ok(response);
        }

        [HttpGet]
        [Route("{personId:long}")]
        public ActionResult<PersonDetailsModel> Details(long companyId, long personId)
        {
            var response = manager.GetDetailsModel(companyId, personId);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return response;
            }
        }
    }
}
