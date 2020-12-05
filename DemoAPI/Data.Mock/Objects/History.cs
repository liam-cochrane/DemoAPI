using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mock.Objects
{
    public class History
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }

        public string LinkType { get; set; }

        public long LinkId { get; set; }
    }
}
