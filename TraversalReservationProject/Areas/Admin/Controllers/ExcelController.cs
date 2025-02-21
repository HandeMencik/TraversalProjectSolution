using Business.Abstract;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Drawing;
using TraversalReservationProject.Models;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExcelController : Controller
    {
        private readonly TraversalContext _context;
        private readonly IExcelService _excelService;

        public ExcelController(TraversalContext context, IExcelService excelService)
        {
            _context = context;
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();

        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            destinationModels = _context.Destinations.Select(x => new DestinationModel
            {
                City = x.City,
                DayNight = x.DayNight,
                Capacity = x.Capacity,
                Price = x.Price
            }).ToList();
            return destinationModels;


        }
        public IActionResult DestinationExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
            //using (ExcelPackage excel = new ExcelPackage())
            //{
            //    var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");

            //    worksheet.Cells[1, 1].Value = "Şehir";
            //    worksheet.Cells[1, 2].Value = "Tur Süresi";
            //    worksheet.Cells[1, 3].Value = "Fiyat";
            //    worksheet.Cells[1, 4].Value = "Kapasite";

            //    int row = 2;
            //    foreach (var item in DestinationList())
            //    {
            //        worksheet.Cells[row, 1].Value = item.City;
            //        worksheet.Cells[row, 2].Value = item.DayNight;
            //        worksheet.Cells[row, 3].Value = item.Price;
            //        worksheet.Cells[row, 4].Value = item.Capacity;
            //        row++;
            //    }

            //    var fileBytes = excel.GetAsByteArray();
            //    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Rotalar.xlsx");
            //}
        }

    }
}

