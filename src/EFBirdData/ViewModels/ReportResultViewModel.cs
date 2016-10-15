using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBirdData.Controllers;
using EFBirdData.Models;

namespace EFBirdData.ViewModels
{
    public class ReportResultViewModel
    {
        public string Title { get; set; }
        public List<ResultItem> Items { get; set; }
        public ReportResultViewModel()
        {
            Items = new List<ResultItem>() { };
        }
    }
}
