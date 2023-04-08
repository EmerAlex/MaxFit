using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxFit.Models.Dto
{
    public class DrinkFindFilter
    {
        public int Total { get; set; }
        public IEnumerable<DrinkAllQuery> Drinks { get; set; }
    }
}