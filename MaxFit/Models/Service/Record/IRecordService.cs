using MaxFit.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFit.Models.Service.Record
{
    internal interface IRecordService
    {

        IEnumerable<RecordAllQuery> AllRecords();
        bool SaveRecord(Entities.Record record);
        IEnumerable<RecordAllQuery> FindRecords(string initialDate, string  finalDate);
    }
}
