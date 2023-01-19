using MaxFit.Models.Dto;
using MaxFit.Models.Repository.Record;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFit.Models.Service.Record
{
    public class RecordService : IRecordService
    {
        readonly RecordRepository _RecordRepository = new RecordRepository();
        public IEnumerable<RecordAllQuery> AllRecords()
        {
            List<RecordAllQuery> records = new List<RecordAllQuery>();
            _RecordRepository.AllRecords().ForEach(rcd =>{
                records.Add(new RecordAllQuery() {
                    Document = rcd.Docuemnt,
                    Date = rcd.Date.ToString(),
                    Price = rcd.Price
                });
            });
            return records;
        }

        public IEnumerable<RecordAllQuery> FindRecords(string initialDate, string finalDate)
        {
       
            var dateInitial = DateTime.Parse(initialDate);
            var dateFinal = DateTime.Parse(finalDate);
            
            List<RecordAllQuery> records = new List<RecordAllQuery>();
            _RecordRepository.FindRecords(dateInitial, dateFinal).ForEach(rcd => {
                records.Add(new RecordAllQuery()
                {
                    Document = rcd.Docuemnt,
                    Date = rcd.Date.ToString(),
                    Price = rcd.Price
                });
            });
            return records;
        }

        public bool SaveRecord(Entities.Record record)
        {
            return _RecordRepository.SaveRecord(record);
        }

        public int CalculateTotal(IEnumerable<RecordAllQuery> records)
        {
            int result = 0;

            records.ForEach(record =>
            {
                result += record.Price;
            });

            return result;
        }
    }
}
