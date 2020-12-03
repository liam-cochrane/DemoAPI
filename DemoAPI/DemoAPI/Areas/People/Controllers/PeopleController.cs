using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.People.Managers;
using Domain.Areas.People.Models;

namespace DemoAPI.Areas.People.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public ActionResult<IEnumerable<PersonDetailsModel>> Index(string searchTerm = null)
        {
            var search = new PersonSearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet]
        [Route("{companyId:long}")]
        public ActionResult<PersonDetailsModel> Details(long companyId)
        {
            var response = manager.GetDetailsModel(companyId);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return response;
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult Create(PersonCreateModel model)
        {
            try
            {
                manager.SaveCreateModel(model);

                return Ok();
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTIONS
                throw;
            }
        }

        [HttpPut]
        [Route("{companyId:long}")]
        public ActionResult Edit(long companyId, PersonEditModel model)
        {
            try
            {
                manager.SaveEditModel(companyId, model);

                return Ok();
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTIONS
                throw;
            }
        }

        [HttpDelete]
        [Route("{companyId:long}")]
        public ActionResult Delete(long companyId)
        {
            try
            {
                manager.Delete(companyId);

                return Ok();
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTIONS
                throw;
            }
        }
    }
}
