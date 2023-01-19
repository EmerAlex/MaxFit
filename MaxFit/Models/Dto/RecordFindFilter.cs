
using System;
using System.Collections.Generic;

namespace MaxFit.Models.Dto
{
    public class RecordFindFilter
    {
        public int Total { get; set; }
        public IEnumerable<RecordAllQuery> Records { get; set; }
        
    }
}
