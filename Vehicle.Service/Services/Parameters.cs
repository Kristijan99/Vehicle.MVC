using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service.Services
{
    public class Parameters
    {
        public class FilterParameters
        {
            public string Search { get; set; }
        }
        public class PageParameters
        {
            public int PageSize { get; set; }
            public int Page { get; set; }
        }
        public class SortParameters
        {
            public string Sort { get; set; }
            public string Direction { get; set; }
        }
    }
}
