using BayMarch.Data;
using BayMarch.Dto.Filter;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BayMarch.Services
{
    public class ReportService : IReportService
    {
        private readonly DataContext _context;
        public ReportService(DataContext context)
        {
            _context = context;
        }

        public IDictionary<string, int> GetDefault()
        {
            IDictionary<string,int> numberNames = new Dictionary<string,int>();

            numberNames.Add( "One",1); //adding a key/value using the Add() method
            numberNames.Add( "Two",2);
            numberNames.Add("Three",3);                    


            return numberNames; 
        }

        public byte[] GetReport(ReportFilter reportFilter)
        {
            StringBuilder str = new StringBuilder();

            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("</table>");

  


            var workbook = new XLWorkbook();


            IXLWorksheet worksheet = workbook.Worksheets.Add("Authors");
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "FirstName";
            worksheet.Cell(1, 3).Value = "LastName";

            for (int index = 1; index <= 3; index++)
            {
                worksheet.Cell(index + 1, 1).Value = (index + 1)* index;
                worksheet.Cell(index + 1, 2).Value = (index + 2) * index;
                worksheet.Cell(index + 1, 3).Value = (index + 3) * index;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return content;

                //return File(content, contentType, fileName);
            }


            //return null;

        }
    }
}
