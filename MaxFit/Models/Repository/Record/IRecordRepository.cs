using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFit.Models.Repository.Record
{
    internal interface IRecordRepository
    {

        IEnumerable<Entities.Record> AllRecords();
        IEnumerable<Entities.Record> FindRecords(DateTime initialDate, DateTime finalDate);
        bool SaveRecord(Entities.Record record);


    }
}
