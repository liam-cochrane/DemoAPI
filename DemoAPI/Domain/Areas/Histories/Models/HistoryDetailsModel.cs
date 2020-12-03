using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.Histories.Models
{
    public class HistoryDetailsModel
    {
        public long HistoryId { get; set; }

        public string Description { get; set; }

        public long UserId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
