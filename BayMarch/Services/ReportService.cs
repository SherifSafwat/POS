using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.IO;
using System.Linq;
using System.Text;

namespace BayMarch.Services
{
    public class ReportService : IReportService
    {
        List<Report> reports;
        private readonly DataContext _context;
        public ReportService(DataContext context)
        {
            _context = context;

            reports = new List<Report>
            {
                new Report() { ReportId = 1, sql = "select * from product", AName = "r1", EName = "r1" },
                new Report() { ReportId = 2, sql = "select * from seller", AName = "r2", EName = "r2" }
            };


        }

        //public IDictionary<string, int> GetDefault()
        public List<Report> GetDefault()        
        {
            return reports; 
        }

        public byte[] GetReport(ReportFilter reportFilter)
        {


            //Querying with Object Services and Entity SQL
            /*string sqlString = "SELECT VALUE st FROM SchoolDBEntities.Students " +
                                "AS st WHERE st.StudentName == 'Bill'";

            var objctx = (ctx as IObjectContextAdapter).ObjectContext;

            ObjectQuery<Student> student = objctx.CreateQuery<Student>(sqlString);
            Student newStudent = student.First<Student>();*/

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "query";
                command.CommandType = CommandType.Text;

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    //var entities = new List<T>();

                    while (result.Read())
                    {
                        result[0].ToString();
                        
                        //entities.Add(map(result));
                    }

                    //return entities;
                }
            }
                         


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
