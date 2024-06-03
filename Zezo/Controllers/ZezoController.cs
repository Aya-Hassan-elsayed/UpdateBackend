using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using Zezo.ApplicationIdntity;
using Zezo.Dtos;
using Zezo.Models;


namespace Zezo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZezoController : ControllerBase
    {
        private readonly rsc_v2Context _context;
        private readonly ApplicationDbContext _contextuser;
        private readonly UserManager<IdentityUser> _userManager;
        public ZezoController(rsc_v2Context context, ApplicationDbContext contextuser, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _contextuser = contextuser;
            _userManager = userManager;
        }

        [HttpGet("getlogdata")]
        [Authorize(Roles =("manger,bigmanger"))]
        public IActionResult getlogtabel(string? username)
        {

                if (username != null)
                {
                    var isexcting = _contextuser.ExcelUpdateLogs.FirstOrDefault(c => c.UserName == username);

                    if (isexcting == null)
                    {
                        return NotFound("sorry , this user not found");
                    }
                    else
                    {
                        var user = _contextuser.ExcelUpdateLogs.Where(u => u.UserName == isexcting.UserName).OrderByDescending(x=>x.UpdatedAt).ToList();
                        return Ok(user);
                    }

                }
            else
            {
                return BadRequest("Username parameter is required.");
            }


        }


        [HttpGet("GetLogWithDate")]
        [Authorize(Roles = ("manger,bigmanger"))]
        public IActionResult getlogtabelwithDate(DateTime updatedDate)
        {

            if (updatedDate != null)
            {
                var dateOnly = updatedDate.Date;
                var isexcting = _contextuser.ExcelUpdateLogs.FirstOrDefault(c => c.UpdatedAt.Date == dateOnly);

                if (isexcting == null)
                {
                    return NotFound("sorry , No Data inserted this date");
                }
                else
                {
                    var logDate = _contextuser.ExcelUpdateLogs.Where(u => u.UpdatedAt.Date == isexcting.UpdatedAt.Date).OrderByDescending(x => x.UpdatedAt).ToList();
                    return Ok(logDate);
                }

            }
            else
            {
                return BadRequest("Date is required.");
            }


        }

        [HttpPut("updatedLara")]
        [Authorize(Roles = "admin,manger,bigmanger")]
        public async Task<IActionResult> UpdatedLara(IFormFile file)
        {
            try
            {

                var user = await _userManager.GetUserAsync(User);
                var list = new List<Updatedatadto>();

                var networkPath = @"\\10.100.102.70\update_logs\re_print";

                // Create the directory if it doesn't exist
                if (!Directory.Exists(networkPath))
                {
                    Directory.CreateDirectory(networkPath);
                }
                var filePath = Path.Combine(networkPath, file.FileName);

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
                                        if (DateTime.TryParseExact(item.Print_Date, "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate) ||
                                            DateTime.TryParseExact(item.Print_Date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out printDate))
                                        {
                                            requestToUpdate.PrintDate = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                        }
                                        else
                                        {
                                            return BadRequest("Take Care Pro, Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy h:m:s tt' or 'M/d/yyyy'.");
                                        }
                                    }


                                  

                                    // Update other properties as needed
                                }
                            }



                            await _context.SaveChangesAsync();

                            try
                            {
                                if (user != null)
                                {
                                    var log = new ExcelUpdateLog
                                    {
                                        // id =Convert.ToInt32(user.Id) ,
                                        UserName = user.UserName,
                                        UpdatedAt = DateTime.Now,
                                        RecordsUpdated = rowCount - 1 ,
                                        FileContentpath = filePath

                                    };

                                    _contextuser.ExcelUpdateLogs.Add(log);
                                    _contextuser.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }
                        }

                        else
                        {
                            return BadRequest("Worksheet is null.");
                        }
                    }
                }
                return Ok("Well Done Pro, Updated Successfully.");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Database update error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("sha7n")]
        [Authorize(Roles = "teamleader,manger,bigmanger")]
        public async Task<IActionResult> updatedtoislam(IFormFile file)
        {

           
                var user = await _userManager.GetUserAsync(User);
                var list = new List<Updatedatadto>();

            var networkPath = @"\\10.100.102.70\update_logs\shipping";

            // Create the directory if it doesn't exist
            if (!Directory.Exists(networkPath))
            {
                Directory.CreateDirectory(networkPath);
            }

           

            var filePath = Path.Combine(networkPath, file.FileName);

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
                        if (worksheet == null)
                        {
                            return BadRequest("Worksheet is null.");
                        }

                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var requestnumber = worksheet.Cells[row, 1];
                            var CetrCell = worksheet.Cells[row, 2];
                            var TofedexCell = worksheet.Cells[row, 3];




                            if (requestnumber?.Value == null || CetrCell?.Value == null)
                            {
                                return BadRequest($"Oops pro, Some value is null in row {row} in the Excel. Please check the values and update again.");
                            }

                            list.Add(new Updatedatadto
                            {
                                requestNumber = requestnumber.Value.ToString().Trim(),
                                cert = CetrCell.Value.ToString().Trim(),
                                Tofedex = TofedexCell?.Value?.ToString().Trim()
                            });
                        }

                        foreach (var item in list)
                        {
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
                                        return BadRequest("OOPS Pro, Invalid value for Tawheed. It must be either 1, 2, or 3.");
                                    }
                                }

                                if (item.Tofedex != null)
                                {
                                    if (DateTime.TryParseExact(item.Tofedex, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate) ||
                                       DateTime.TryParseExact(item.Tofedex, "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out printDate))
                                    {
                                        requestToUpdate.Tofedex = new DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                    }
                                    else
                                    {
                                        return BadRequest("Take Care Pro, Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy'.");
                                    }
                                }
                            }

                            await _context.SaveChangesAsync();
                        }

                        if (user != null)
                        {
                            var log = new ExcelUpdateLog
                            {
                                UserName = user.UserName,
                                UpdatedAt = DateTime.Now,
                                RecordsUpdated = rowCount - 1,                           
                                FileContentpath  = filePath
                            };

                            _contextuser.ExcelUpdateLogs.Add(log);
                            await _contextuser.SaveChangesAsync();
                        }
                    }
                }
                return Ok("Well Done Pro, Updated Successfully.");
            
          
           
        }

        [HttpPut("updatedKamel")]
        [Authorize(Roles = "user,manger,bigmanger")]
        public async Task<IActionResult> updatedKamel(IFormFile file)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);


                var list = new List<Updatedatadto>();


                var networkPath = @"\\10.100.102.70\update_logs\print";

                // Create the directory if it doesn't exist
                if (!Directory.Exists(networkPath))
                {
                    Directory.CreateDirectory(networkPath);
                }
                var filePath = Path.Combine(networkPath, file.FileName);

                // Save the uploaded file to the network path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                using (var stream = new MemoryStream())
                {

                    byte[] fileContent = stream.ToArray();
                 
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
                                        if (surveycel == 1 || surveycel == 2 || surveycel == 3 || surveycel == 4 || surveycel == 5 || surveycel == 6)
                                        {
                                            requestToUpdate.SurveyReview = surveycel;
                                        }

                                        else
                                        {
                                            BadRequest("take care pro ");
                                        }
                                    }

                                   

                                    if (item.Print_Date != null)
                                    {
                                        if (DateTime.TryParseExact(item.Print_Date, "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate) ||
                                            DateTime.TryParseExact(item.Print_Date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out printDate))
                                        {

                                            requestToUpdate.PrintDate = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                          
                                        }
                                        else
                                        {
                                            return BadRequest("Take Care Pro, Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy h:m:s tt' or 'M/d/yyyy'.");
                                        }

                                    }
                                }

                                // Update other properties as needed
                            }

                            await _context.SaveChangesAsync();
                            try
                            {
                                if (user != null)
                                {
                                    var log = new ExcelUpdateLog
                                    {
                                        // id =Convert.ToInt32(user.Id) ,
                                        UserName = user.UserName,
                                        UpdatedAt = DateTime.Now,
                                        RecordsUpdated = rowCount - 1 ,
                                        FileContentpath = filePath

                                    };

                                    _contextuser.ExcelUpdateLogs.Add(log);
                                    _contextuser.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }

                        }
                        else
                        {
                            return BadRequest("Worksheet is null.");
                        }
                    }
                }
                return Ok("Well Done Pro, Updated Successfully.");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Database update error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = "teamleader,manger,bigmanger")]
        [HttpPut("e3ada")]
        public async Task<IActionResult> updatedtoislamshipingorderstatus(IFormFile file)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var list = new List<Updatedatadto>();

                var networkPath = @"\\10.100.102.70\update_logs\re_shipping";

                // Create the directory if it doesn't exist
                if (!Directory.Exists(networkPath))
                {
                    Directory.CreateDirectory(networkPath);
                }

                var filePath = Path.Combine(networkPath, file.FileName);

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

                                 
                                    if (item.Print_Date != null)
                                    {
                                        if (DateTime.TryParseExact(item.Print_Date, "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime printDate) ||
                                            DateTime.TryParseExact(item.Print_Date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out printDate))
                                        {
                                            requestToUpdate.PrintDate = new System.DateOnly(printDate.Year, printDate.Month, printDate.Day);
                                        }
                                        else
                                        {
                                            return BadRequest("Take Care Pro, Invalid value for Print_Date. It must be a valid date in the format 'M/d/yyyy h:m:s tt' or 'M/d/yyyy'.");
                                        }
                                    }
                                }
                            }
                            await _context.SaveChangesAsync();

                            try
                            {
                                if (user != null)
                                {
                                    var log = new ExcelUpdateLog
                                    {
                                        // id =Convert.ToInt32(user.Id) ,
                                        UserName = user.UserName,
                                        UpdatedAt = DateTime.Now,
                                        RecordsUpdated = rowCount - 1 ,
                                        FileContentpath = filePath
                                    };

                                    _contextuser.ExcelUpdateLogs.Add(log);
                                    _contextuser.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }

                        }
                        else
                        {
                            return BadRequest("Worksheet is null.");
                        }
                    }
                }
                return Ok("Well Done Pro, Updated Successfully.");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Database update error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
