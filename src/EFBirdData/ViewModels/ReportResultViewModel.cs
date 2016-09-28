using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBirdData.Controllers;

namespace EFBirdData.ViewModels
{
    public class ReportResultViewModel
    {
        public List<ReportItem> Items { get; set; }
        public ReportResultViewModel()
        {
            Items = new List<ReportItem>() { };
        }
    }
}
