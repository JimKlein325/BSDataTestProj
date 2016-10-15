using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBirdData.ViewModels;

namespace EFBirdData.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<EFBirdData.Models.Bird> Bird { get; set; }
       // public  IEnumerable<RecentSightingViewModel> RecentSightings { get; set; }
        public ViewModels.SightingsForYearReportViewModel ReportView { get; set; }
        public LinkedTableViewModel LinkedResultTable { get; set; }
        public ReportResultViewModel TopObservers { get; set; }

    }
}
