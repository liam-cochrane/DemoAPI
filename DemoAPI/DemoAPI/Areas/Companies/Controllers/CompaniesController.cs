using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.Companies.Managers;
using Domain.Areas.Companies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DemoAPI.Areas.Companies.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly CompaniesManager manager;

        public CompaniesController(ILogger<CompaniesController> logger)
        {
            _logger = logger;
            manager = new CompaniesManager();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<CompanyDetailsModel>> Index(string searchTerm = null)
        {
            var search = new CompanySearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{companyId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompanyDetailsModel> Details(long companyId)
        {
            var response = manager.GetDetailsModel(companyId);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return response;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(CompanyCreateModel model)
        {
            try
            {
                var id = manager.SaveCreateModel(model);

                return Created("[controller]/" + id, new Object());
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTIONS
                throw;
            }
        }

        [HttpPut("{companyId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Edit(long companyId, CompanyEditModel model)
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

        [HttpDelete("{companyId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
