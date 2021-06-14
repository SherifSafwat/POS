using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Services;
using BayMarch.Dto.Filter;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/reports
        [HttpGet]
        [Route("GetDefault")]
        public IActionResult GetDefault()
        {
            return Ok(_reportService.GetDefault());
        }

        [HttpPost]
        [Route("GetReport")]
        public IActionResult PostReport(ReportFilter reportFilter)
        {
            return File(_reportService.GetReport(reportFilter), "application/vnd.ms-excel", "report.xls");
        }


    }
}


/*
 *             //HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Information" + DateTime.Now.Year.ToString() + ".xls");

            //HttpContext.Response.Headers.Add("o");

            //this.Response.ContentType = "application/vnd.ms-excel";
            //byte[] temp = System.Text.Encoding.UTF8.GetBytes(_reportService.GetReport(reportFilter).ToString());

            //return File(_reportService.GetReport(reportFilter), "application/vnd.ms-excel");
 * 
 *             //HttpResponseMessage fullResponse = Request....CreateResponse(HttpStatusCode.OK);
            //fullResponse.Content = new StreamContent(_reportService.GetReport(reportFilter).ToString());
            //fullResponse.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
            //return fullResponse;

            //var source = new MockStream(_reportService.GetReport(reportFilter), true, true);

            //StreamContent s = new MemoryStream(_reportService.GetReport(reportFilter));
            

            //MemoryStream ws = new MemoryStream(_reportService.GetReport(reportFilter));
            //StreamContent s = new StreamContent(ws);

            //Stream ss = new StreamContent(ws.);
            //ws.WriteTo(ss);

            //HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Information" + DateTime.Now.Year.ToString() + ".xls");

            //Response.Headers.Add("Content-Length", "1000");

            //HttpContext.Response.ContentType = "application/octet-stream";
            //Response.Headers.Add("ContentType", "application/vnd.ms-excel");

            Response.ContentType = "application/octet-stream";
            Response.Headers.Add("content-disposition", "attachment");
            ///Response.C


            //byte[] temp = System.Text.Encoding.UTF8.GetBytes(_reportService.GetReport(reportFilter).ToString());
            ////return Ok(s);

            //return File(_reportService.GetReport(reportFilter), "text/csv", "fileName");
            //return Ok(_reportService.GetReport(reportFilter));
 * 
 
 
 
 
 */
