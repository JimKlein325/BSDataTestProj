using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBirdData.Models;

namespace EFBirdData.ViewModels
{
    public class LinkedTableViewModel
    {
        public string TableTitle { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<ResultItem> Items { get; set; }
        public LinkedTableViewModel()
        {
            Items = new List<ResultItem>() { };
        }

    }
}
