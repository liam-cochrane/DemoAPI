using Data.Mock;
using Domain.Areas.Histories.Models;
using Domain.Areas.Histories.Consts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domain.Areas.Companies.Managers
{
    public class HistoriesManager
    {
        private readonly DataContext dc;

        public HistoriesManager()
        {
            dc = new DataContext();
        }

        public IEnumerable<HistoryDetailsModel> GetIndexModel(long companyId, HistorySearchModel search)
        {
            var company = dc.Companies.Find(X => X.Id == companyId);

            if (company == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                var items = dc.Histories.AsQueryable().Where(X => (X.LinkType == HistoriesConsts.LinkType_Company) && (X.LinkId == company.Id));

                if (search != null)
                {
                    if (!string.IsNullOrEmpty(search.Term))
                    {
                        var words = search.Term.ToUpper().Split(" ");

                        foreach (string word in words)
                        {
                            items = items.Where(X => X.Description.ToUpper().Contains(word));
                        }
                    }
                }

                var response = new List<HistoryDetailsModel>();

                foreach (var item in items)
                {
                    response.Add(new HistoryDetailsModel
                    {
                        HistoryId = item.Id,
                        Description = item.Description,
                        TimeStamp = item.TimeStamp
                    });
                }

                return response;
            }
        }

        public HistoryDetailsModel GetDetailsModel(long companyId, long id)
        {
            var company = dc.Companies.Find(X => X.Id == companyId);

            if (company == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                var item = dc.Histories.Find(X => (X.LinkType == HistoriesConsts.LinkType_Company) &&
                    (X.LinkId == company.Id) &&
                    (X.Id == id));

                if (item == null)
                {
                    return null;
                }
                else
                {
                    return new HistoryDetailsModel
                    {
                        HistoryId = item.Id,
                        Description = item.Description,
                        TimeStamp = item.TimeStamp
                    };
                }
            }
        }
    }
}
