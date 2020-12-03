using Domain.Areas.Histories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.Companies.Managers
{
    public class HistoriesManager
    {
        public IEnumerable<HistoryDetailsModel> GetIndexModel(HistorySearchModel model)
        {
            throw new NotImplementedException();
        }

        public HistoryDetailsModel GetDetailsModel(long companyId, long id)
        {
            if (false) //IF COMPANY NOT FOUND
            {
                return null;
            }
            else
            {
                return new HistoryDetailsModel
                {
                    Description = id.ToString(),
                    TimeStamp = DateTime.Now,
                    UserId = 123456
                };
            }
        }
    }
}
