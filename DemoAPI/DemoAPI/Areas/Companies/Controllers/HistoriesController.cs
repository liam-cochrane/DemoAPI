using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.Companies.Managers;
using Domain.Areas.Histories.Models;

namespace DemoAPI.Areas.Companies.Controllers
{
    [ApiController]
    [Route("Companies/{companyId:long}/[controller]/")]
    public class HistoriesController : ControllerBase
    {
        private readonly ILogger<HistoriesController> _logger;
        private readonly HistoriesManager manager;

        public HistoriesController(ILogger<HistoriesController> logger)
        {
            _logger = logger;
            manager = new HistoriesManager();
        }

        [HttpGet]
        public ActionResult<IEnumerable<HistoryDetailsModel>> Index(long companyId, string searchTerm = null)
        {
            var search = new HistorySearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(companyId, search);

            return Ok(response);
        }

        [HttpGet("{historyId:long}")]
        public ActionResult<HistoryDetailsModel> Details(long companyId, long historyId)
        {
            var response = manager.GetDetailsModel(companyId, historyId);

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
