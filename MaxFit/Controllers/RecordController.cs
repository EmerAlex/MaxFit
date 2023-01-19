using MaxFit.Models.Dto;
using MaxFit.Models.Login;
using MaxFit.Models.Service.Record;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace MaxFit.Controllers
{
    public class RecordController : Controller
    {
        readonly RecordService _recordService = new RecordService();
        [HttpGet]
        [Authorize]
        public JsonResult FindAllRecords()
        {

            return Json(new { data = _recordService.AllRecords() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize]
        public JsonResult FindRecords(RecordSearchDTO recordSubmit)
        {
            var results = new RecordFindFilter();
            var records = _recordService.FindRecords(recordSubmit.InitialDate, recordSubmit.FinlaDate);
            results.Total = _recordService.CalculateTotal(records);
            results.Records = records;


            return Json(new { result =  results}, JsonRequestBehavior.AllowGet);
        }


    }
}