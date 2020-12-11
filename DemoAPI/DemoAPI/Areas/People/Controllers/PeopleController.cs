using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.People.Managers;
using Domain.Areas.People.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(typeof(IEnumerable<PersonDetailsModel>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PersonDetailsModel>> Index(string searchTerm = null)
        {
            var search = new PersonSearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{personId:long}")]
        [ProducesResponseType(typeof(PersonDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonDetailsModel> Details(long personId)
        {
            var response = manager.GetDetailsModel(personId);

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
        [ProducesResponseType(typeof(PersonDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(PersonCreateModel model)
        {
            try
            {
                var id = manager.SaveCreateModel(model);

                var responseModel = manager.GetDetailsModel(id);

                return CreatedAtAction(nameof(Details), new { personId = id }, responseModel);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpPut("{personId:long}")]
        [ProducesResponseType(typeof(PersonDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Edit(long personId, PersonEditModel model)
        {
            try
            {
                manager.SaveEditModel(personId, model);

                var responseModel = manager.GetDetailsModel(personId);

                return Ok(responseModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{personId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long personId)
        {
            try
            {
                manager.Delete(personId);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
