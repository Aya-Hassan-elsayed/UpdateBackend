using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zezo.Dtos;
using Zezo.Models;
//using Zezo.Models;
//using Zezo.Models;
using Zezo.ViewModel;

namespace Zezo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZezoController : ControllerBase
    {
        private readonly rsc_v2Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ZezoController(rsc_v2Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }





        [HttpPut("updatedLara")]
        [Authorize(Roles = "admin,manager,bigmanger")]
        public async Task<IActionResult> UpdatedLara(IFormFile file)
        {
            var list = new List<Updatedatadto>();


            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var Id_shepingordercell = worksheet.Cells[row, 1];
                            var statusCell = worksheet.Cells[row, 2];
                            var printCell = worksheet.Cells[row, 3];
                            var printdate = worksheet.Cells[row, 4];

                            // Check if any cells in the row are null
                            if (Id_shepingordercell.Value == null || statusCell.Value == null || printCell.Value == null)
                            {
                                return BadRequest($"Oops, Eng Lara, Some values are null in rows {row}. Please check the values equal null and update again.");

                            }

                            // Cells are not null, proceed to add to the list
                            list.Add(new Updatedatadto
                            {
                                Id_shepingorder = Id_shepingordercell.Value.ToString().Trim(),
                                Status = statusCell.Value.ToString().Trim(),
                                print_satuts = printCell.Value.ToString().Trim(),
                                Print_Date = printdate.Value != null ? printdate.Value.ToString().Trim() : null,

                            });

                        }

                        // Check if any null values were found



                        foreach (var item in list)
                        {
                            // Find the request using the unique request number
                            var requestsToUpdateindb = _context.ShippingordersStatuses
                                .Where(r => r.IdShippingorder.ToString() == item.Id_shepingorder)
                                .ToList();

                            foreach (var requestToUpdate in requestsToUpdateindb)
                            {
                                if (int.TryParse(item.Status, out int statusvalue))
                                {
                                    if (statusvalue == 1 || statusvalue == 2 || statusvalue == 3 || statusvalue == 4 || statusvalue == 5 || statusvalue == 5 ||
                                        statusvalue == 7 || statusvalue == 8 || statusvalue == 9 || statusvalue == 10 || statusvalue == 11 || statusvalue == 12 ||
                                        statusvalue == 13 || statusvalue == 14 || statusvalue == 15 || statusvalue == 16 || statusvalue == 17 || statusvalue == 18)
                                    {
                                        requestToUpdate.Status = statusvalue;
                                    }

                                    else
                                    {
                                        return BadRequest(" OOPS, Take Care Eng Lara in the Status , One Or More Value  Out Of the Scope ");
                                    }
                                }

                                if (short.TryParse(item.print_satuts, out short printStatus))
                                {

                                    if (printStatus == 0 || printStatus == 1)
                                    {
                                        requestToUpdate.PrintStatus = printStatus;
                                    }
                                    else
                                    {
                                        // Handle the case where printStatus is not 0 or 1 (e.g., log a message, throw an exception, etc.)
                                        return BadRequest("Take Care pro ,Invalid value for print_satuts. It must be either 0 or 1.");
                                    }
                                }

                                if (item.Print_Date != null)
                                {
                                    if (DateTime.TryParseExact(item.Print_Date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate))
                                    {
                                        requestToUpdate.PrintDate = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);

                                    }

                                    else
                                    {
                                        // Handle the case where Print_Date is not a valid date or doesn't match the expected format
                                        return BadRequest("Take Care Pro ,Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy '.");
                                    }
                                }

                                // Update other properties as needed
                            }
                        }



                        await _context.SaveChangesAsync();
                    }

                    else
                    {
                        return BadRequest("Worksheet is null.");
                    }
                }
            }
            return Ok("Well  done pro, Updated Successfully.");
        }


        [HttpPut("updatedKamel")]

        [Authorize(Roles = "user,manger,bigmanger")]
        public async Task<IActionResult> updatedKamel(IFormFile file)
        {


            var list = new List<Updatedatadto>();


            using (var stream = new MemoryStream())
            {

                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var requestnumber = worksheet.Cells[row, 1];
                            var TawhedCell = worksheet.Cells[row, 2];
                            var print_statusCell = worksheet.Cells[row, 3];
                            var surveyreview = worksheet.Cells[row, 4];
                            var printdate = worksheet.Cells[row, 5];


                            if (requestnumber.Value == null || TawhedCell.Value == null || print_statusCell.Value == null || surveyreview.Value == null || printdate.Value == null)

                            {
                                return BadRequest($"Oops Eng Kamel, Some value is row {row} in the Excel. Please check the values equal null and update again.");
                            }


                            // Check if cells exist before accessing their values
                            if (requestnumber.Value != null && TawhedCell.Value != null && print_statusCell.Value != null && surveyreview.Value != null && printdate.Value != null)
                            {
                                list.Add(new Updatedatadto
                                {

                                    requestNumber = requestnumber.Value.ToString().Trim(),
                                    tawhed = TawhedCell.Value.ToString().Trim(),
                                    print_satuts = print_statusCell.Value.ToString().Trim(),
                                    Print_Date = printdate.Value.ToString().Trim(),
                                    Survey_review = surveyreview.Value.ToString().Trim()

                                });
                            }
                        }


                        foreach (var item in list)
                        {

                            // Find the request using the unique request number

                            var requestsToUpdateindb = _context.Assignements
                                .Where(r => r.Requestnumber == item.requestNumber)
                                .ToList();



                            // If multiple rows are found for the same request number, you may need to handle it accordingly.
                            // For now, I'm assuming that you want to update all matching rows.

                            foreach (var requestToUpdate in requestsToUpdateindb)
                            {


                                if (short.TryParse(item.tawhed, out short certValue))
                                {
                                    if (certValue == 0 || certValue == 1)
                                    {
                                        requestToUpdate.Tawheed = certValue;
                                    }
                                    else
                                    {
                                        return BadRequest("OOPs ,Pro ,Invalid value for Tawheed. It must be either 0 or 1.  ");
                                    }

                                }



                                if (short.TryParse(item.print_satuts, out short printStatus))
                                {

                                    if (printStatus == 0 || printStatus == 1)
                                    {

                                        requestToUpdate.PrintStatus = printStatus;
                                    }
                                    else
                                    {
                                        // Handle the case where printStatus is not 0 or 1 (e.g., log a message, throw an exception, etc.)
                                        return BadRequest("Take Care pro ,Invalid value for print_satuts. It must be either 0 or 1.");
                                    }
                                }


                                if (short.TryParse(item.Survey_review, out short surveycel))
                                {
                                    if (surveycel == 1 || surveycel == 3 || surveycel == 4 || surveycel == 5 || surveycel == 6)
                                    {
                                        requestToUpdate.SurveyReview = surveycel;
                                    }

                                    else
                                    {
                                        BadRequest("take care pro ");
                                    }
                                }


                                if (item.Print_Date == null)
                                {
                                    requestToUpdate.PrintDate = System.DateOnly.MinValue;
                                }
                                else if (DateTime.TryParseExact(item.Print_Date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate))
                                {
                                    requestToUpdate.PrintDate = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                }
                                else
                                {
                                    // Handle the case where Print_Date is not a valid date or doesn't match the expected format
                                    return BadRequest("Take Care Pro ,Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy'.");
                                }




                            }







                            // Update other properties as needed

                        }



                        await _context.SaveChangesAsync();


                    }
                    else
                    {
                        return BadRequest("Worksheet is null.");
                    }
                }
            }
            return Ok("Well done pro, Updated Successfully.");
        }


        [HttpPut("sha7n")]
        [Authorize(Roles = "teamleader,manger,bigmanger")]
        public async Task<IActionResult> updatedtoislam(IFormFile file)
        {
            var list = new List<Updatedatadto>();


            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var requestnumber = worksheet.Cells[row, 1];
                            var CetrCell = worksheet.Cells[row, 2];
                            var TofedexCell = worksheet.Cells[row, 3];


                            if (requestnumber.Value == null || CetrCell.Value == null)

                            {
                                return BadRequest($"Oops Eng pro, Some value is null {row} in the Excel. Please check the values equal null and update again.");
                            }


                            // Check if cells exist before accessing their values
                            if (requestnumber.Value != null && CetrCell.Value != null)
                            {
                                list.Add(new Updatedatadto
                                {

                                    requestNumber = requestnumber.Value.ToString().Trim(),
                                    cert = CetrCell.Value.ToString().Trim(),
                                    Tofedex = TofedexCell.Value != null ? TofedexCell.Value.ToString().Trim() : null,


                                });
                            }
                        }


                        foreach (var item in list)
                        {

                            // Find the request using the unique request number
                            var requestsToUpdateindb = _context.Assignements
                                .Where(r => r.Requestnumber == item.requestNumber)
                                .ToList();

                            foreach (var requestToUpdate in requestsToUpdateindb)
                            {


                                if (short.TryParse(item.cert, out short certValue))
                                {
                                    if (certValue == 1 || certValue == 2 || certValue == 3)
                                    {
                                        requestToUpdate.Cert = certValue;
                                    }

                                    else
                                    {
                                        return BadRequest("OOPS ,Pro ,Invalid value for Tawheed. It must be either 1 or 2 or 3  ");
                                    }

                                }


                                if (item.Tofedex != null)
                                {
                                    if (DateTime.TryParseExact(item.Tofedex, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate))
                                    {
                                        requestToUpdate.Tofedex = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                    }

                                    else

                                    {
                                        // Handle the case where Print_Date is not a valid date or doesn't match the expected format
                                        return BadRequest("Take Care Pro ,Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy '.");
                                    }
                                }


                            }

                        }



                        await _context.SaveChangesAsync();


                    }
                    else
                    {
                        return BadRequest("Worksheet is null.");
                    }
                }
            }
            return Ok("Well Done Pro, Updated Successfully.");
        }

        [Authorize(Roles = "teamleader,manger,bigmanger")]

        [HttpPut("e3ada")]
        public async Task<IActionResult> updatedtoislamshipingorderstatus(IFormFile file)
        {
            var list = new List<Updatedatadto>();


            using (var stream = new MemoryStream())
            {
                // var clientIpAddress = _HttpContextAccessor?.HttpContext?.Connection.RemoteIpAddress;
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var Id_shippingorder = worksheet.Cells[row, 1];
                            var reCetrCell = worksheet.Cells[row, 2];
                            var TofedexCell = worksheet.Cells[row, 3];


                            if (Id_shippingorder.Value == null || reCetrCell.Value == null)

                            {
                                return BadRequest($"Oops Pro, Some value is null {row} in the Excel. Please check the values equal null and update again.");
                            }


                            // Check if cells exist before accessing their values
                            if (Id_shippingorder.Value != null && reCetrCell.Value != null)
                            {
                                list.Add(new Updatedatadto
                                {
                                    Id_shepingorder = Id_shippingorder.Value.ToString().Trim(),
                                    recert = reCetrCell.Value.ToString().Trim(),
                                    Tofedex = TofedexCell.Value != null ? TofedexCell.Value.ToString().Trim() : null,


                                });
                            }
                        }


                        foreach (var item in list)
                        {

                            // Find the request using the unique request number
                            var requestsToUpdateindb = _context.ShippingordersStatuses
                                .Where(r => r.IdShippingorder.ToString() == item.Id_shepingorder)
                                .ToList();

                            foreach (var requestToUpdate in requestsToUpdateindb)
                            {


                                if (short.TryParse(item.recert, out short recert))
                                {
                                    if (recert == 1 || recert == 2 || recert == 3)
                                    {
                                        requestToUpdate.Recert = recert;
                                    }
                                    else
                                    {
                                        return BadRequest("OOPs ,Pro ,Invalid value for recert. It must be either 1 or 2 or 3 .   ");
                                    }

                                }

                                if (item.Tofedex != null)
                                {
                                    if (DateTime.TryParseExact(item.Tofedex, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate))
                                    {
                                        requestToUpdate.Tofedex = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                    }

                                    else
                                    {
                                        // Handle the case where Print_Date is not a valid date or doesn't match the expected format
                                        return BadRequest("Take Care Pro ,Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy '.");
                                    }

                                }


                            }

                        }



                        await _context.SaveChangesAsync();


                    }
                    else
                    {
                        return BadRequest("Worksheet is null.");
                    }
                }
            }
            return Ok("Well done pro, Updated Successfully.");
        }

    }
}
