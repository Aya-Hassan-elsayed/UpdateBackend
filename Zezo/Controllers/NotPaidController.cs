using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Globalization;
using Zezo.ApplicationIdntity;
using Zezo.Dtos;
using Zezo.Models;

namespace Zezo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotPaidController : ControllerBase
    {
        private readonly rsc_v2Context _Context;
        private readonly ApplicationDbContext _usercontext;
        private readonly UserManager<IdentityUser> _userManager;
        // using Excel = Microsoft.Office.Interop.Excel;

        public NotPaidController(rsc_v2Context Context, ApplicationDbContext usercontext, UserManager<IdentityUser> userManager)
        {
            _Context = Context;
            _usercontext = usercontext;
            _userManager = userManager;
        }


        [HttpPost("Print_NotPaid")]
        [Authorize(Roles = ("admin,manger"))]
        public async Task<IActionResult> UpdPrintNotPaid(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            var list = new List<UpdateNotPaidDto>();

            if (file == null || file.Length == 0)
            {
                return BadRequest("Sorry , The file not exist");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Please make sure that the uploaded file is an Excel file (.xlsx) ");
            }

            var networkPath = @"\\10.100.102.70\update_logs\Print_NotPaid";

            // Create the directory if it doesn't exist
            if (!Directory.Exists(networkPath))
            {
                Directory.CreateDirectory(networkPath);
            }

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);
            var fullFileName = fileName + fileExtension;

            var filePath = Path.Combine(networkPath, fullFileName);


            // Save the uploaded file to the network path
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;
                        //Add Excel data to DTO
                        for (int row = 2; row <= rowCount; row++)
                        {
                            // var shippingID = worksheet.Cells[row, 1];
                            var concate_serial = worksheet.Cells[row, 1];
                            var printStatus = worksheet.Cells[row, 2];
                            var printDate = worksheet.Cells[row, 3];

                            // Check if any cells in the row are null
                            if (concate_serial.Value == null || printStatus.Value == null || printDate.Value == null)
                            {
                                return BadRequest($"Sorry , Some values are null in rows {row}. Please check the values equal null and update again.");
                            }
                            list.Add(new UpdateNotPaidDto
                            {
                                concate_serial = concate_serial.Value.ToString(),
                                print_status = Convert.ToInt32(printStatus.Value),
                                print_date = printDate.Value.ToString()
                            });
                        }


                        foreach (var item in list)
                        {
                            string con_serial = item.concate_serial.ToString();
                            var ship = _Context.ShippingordersNotpaids
                                       .Where(s => s.CancateSeeriall == con_serial).ToList();

                            if (ship != null)
                            {
                                foreach (var sh in ship)
                                {
                                    if (item.print_date != null)
                                    {
                                        if (DateTime.TryParseExact(item.print_date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate) ||
                                DateTime.TryParseExact(item.print_date, "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out printDate))
                                        {
                                            sh.PrintDate = (new DateOnly(printDate.Year, printDate.Month, printDate.Day)).ToString();
                                        }
                                        else
                                        {
                                            return BadRequest("sorry, Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy'.");
                                        }
                                        // sh.PrintDate = item.print_date;
                                    }
                                    if (item.print_status != null)
                                    {
                                        sh.PrintStatus = item.print_status;
                                    }
                                }
                                await _Context.SaveChangesAsync();


                            }
                        }
                        try
                        {
                            if (user != null)
                            {
                                var log = new ExcelUpdateLog
                                {
                                    UserName = user.UserName,
                                    UpdatedAt = DateTime.Now,
                                    RecordsUpdated = rowCount - 1,
                                    FileContentpath = filePath,
                                    PcName = Environment.MachineName
                                };

                                _usercontext.ExcelUpdateLogs.Add(log);
                                _usercontext.SaveChanges();

                            }
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
                    }
                }

            }

            return Ok("The file updated successfuly");
        }


        [HttpPost("Shahn_NotPaid")]
        [Authorize(Roles = ("teamleader,manger"))]
        public async Task<IActionResult> UpdShippingNotPaid(IFormFile file)
        {
            var list = new List<UpdateNotPaidDto>();
            var user = await _userManager.GetUserAsync(User);

            if (file == null || file.Length == 0)
            {
                return BadRequest("Sorry , The file not exist");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Please make sure that the uploaded file is an Excel file (.xlsx) ");
            }

            var networkPath = @"\\10.100.102.70\update_logs\Shahn_NotPaid";

            // Create the directory if it doesn't exist
            if (!Directory.Exists(networkPath))
            {
                Directory.CreateDirectory(networkPath);
            }

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);
            var fullFileName = fileName + fileExtension;

            var filePath = Path.Combine(networkPath, fullFileName);


            // Save the uploaded file to the network path
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;
                        //Add Excel data to DTO
                        for (int row = 2; row <= rowCount; row++)
                        {
                            // var shippingID = worksheet.Cells[row, 1];
                            var concate_serial = worksheet.Cells[row, 1];
                            var recert_notpaid = worksheet.Cells[row, 2];
                            var Tofedex_NotPaid = worksheet.Cells[row, 3];

                            // Check if any cells in the row are null
                            if (concate_serial.Value == null || recert_notpaid.Value == null)
                            {
                                return BadRequest($"Sorry , Some values are null in rows {row}. Please check the values equal null and update again.");
                            }
                            if (Tofedex_NotPaid.Value == null) Tofedex_NotPaid.Value = "";
                            list.Add(new UpdateNotPaidDto
                            {
                                concate_serial = concate_serial.Value.ToString(),
                                recert_notpaid = (recert_notpaid.Value).ToString(),
                                toFedex_notpaid = Tofedex_NotPaid.Value.ToString()
                            });
                        }


                        foreach (var item in list)
                        {
                            string con_serial = item.concate_serial.ToString();
                            var ship = _Context.ShippingordersNotpaids
                                       .Where(s => s.CancateSeeriall == con_serial).ToList();

                            if (ship != null)
                            {
                                foreach (var sh in ship)
                                {
                                    if (item.toFedex_notpaid != null)
                                    {
                                        if (DateTime.TryParseExact(item.toFedex_notpaid, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate) ||
                                                   DateTime.TryParseExact(item.toFedex_notpaid, "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out printDate))
                                        {
                                            sh.TofidexNotPaid = (new DateOnly(printDate.Year, printDate.Month, printDate.Day)).ToString();
                                        }
                                        else
                                        {
                                            if (item.toFedex_notpaid != string.Empty)
                                                return BadRequest("sorry, Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy'.");
                                            else sh.TofidexNotPaid = "";
                                        }
                                        // sh.PrintDate = item.print_date;
                                    }
                                    if (item.recert_notpaid != null)
                                    {
                                        sh.RecertNotPaid = item.recert_notpaid;
                                    }
                                }
                                await _Context.SaveChangesAsync();

                            }
                        }

                        if (user != null)
                        {
                            var Logtbl = new ExcelUpdateLog
                            {
                                UserName = user.UserName,
                                UpdatedAt = DateTime.Now,
                                RecordsUpdated = rowCount - 1,
                                FileContentpath = filePath,
                                PcName = Environment.MachineName
                            };
                            _usercontext.ExcelUpdateLogs.Add(Logtbl);
                            _usercontext.SaveChanges();
                        }

                        //return Ok("The file updated successfuly");
                    }
                }
            }

            return Ok("The file updated successfuly");

        }
    }
}
