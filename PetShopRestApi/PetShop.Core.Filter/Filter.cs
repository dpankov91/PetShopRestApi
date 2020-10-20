using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Filter
{
    public class Filter
    {
        public Filter()
        {

        }
        public string SearchField { get; set; }
        public string SearchValue { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
