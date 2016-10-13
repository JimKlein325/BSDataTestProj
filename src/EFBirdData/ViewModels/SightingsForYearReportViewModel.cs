using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBirdData.ViewModels
{
    public class SightingsForYearReportViewModel
    {
        public string TableName { get; set; }
        public IEnumerable<Models.ResultItem> Items { get; set; }

    }
}
