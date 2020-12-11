using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Companies.Managers;
using Domain.Core.Companies.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoAPI.Areas.Companies.Controllers
{
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
        public ActionResult<IEnumerable<CompanyDetailsModel>> Index(string searchTerm = null)
        {
            var search = new CompanySearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{companyId:long}")]
        public ActionResult<CompanyDetailsModel> Details(long companyId)
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
        public ActionResult Create(CompanyCreateModel model)
        {
            try
            {
                manager.SaveCreateModel(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpPut("{companyId:long}")]
        public ActionResult Edit(long companyId, CompanyEditModel model)
        {
            try
            {
                manager.SaveEditModel(companyId, model);

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{companyId:long}")]
        public ActionResult Delete(long companyId)
        {
            try
            {
                manager.Delete(companyId);

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
