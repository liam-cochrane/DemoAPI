using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.Companies.Managers;
using Domain.Areas.Companies.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Route("")]
        public ActionResult<IEnumerable<CompanyDetailsModel>> Index(string searchTerm = null)
        {
            var search = new CompanySearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet]
        [Route("{companyId:long}")]
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
        [Route("")]
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

        [HttpPut]
        [Route("{companyId:long}")]
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
