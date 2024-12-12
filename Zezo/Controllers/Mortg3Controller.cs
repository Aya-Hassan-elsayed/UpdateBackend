using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Net;
using Zezo.ApplicationIdntity;
using Zezo.Dtos;
using Zezo.Models;

namespace Zezo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mortg3Controller : ControllerBase
    {
        private readonly rsc_v2Context _context;
        private readonly ApplicationDbContext _usercontext;
        private readonly UserManager<IdentityUser> _userManger;
        public Mortg3Controller(rsc_v2Context context, ApplicationDbContext usercontext, UserManager<IdentityUser> userManger)
        {
            _context = context;
            _usercontext = usercontext;
            _userManger = userManger;
        }

        [Authorize(Roles = ("teamleader,manger"))]
        [HttpPut("NEW_ORDERS")]
        public async Task<ActionResult> update_Assign(IFormFile file)
        {
            var user = await _userManger.GetUserAsync(User);
            var networkPath = @"\\10.100.102.70\update_logs\New_Orders";
            var listupdate = new List<UpdateMortg3>();


            if (file == null)
            {
                return BadRequest("Plz insert Excel File .. ");
            }
            if (!Path.GetExtension(file.FileName).Equals(".xlsx", System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Please make sure that the uploaded file is an Excel file (.xlsx) ");
            }
            if (!Directory.Exists(networkPath))
            {
                Directory.CreateDirectory(networkPath);
            }

            var FileName = Path.GetFileNameWithoutExtension(file.FileName);
            var File_Extenssion = Path.GetExtension(file.FileName);
            var FullName = FileName + File_Extenssion;
            var FilePath = Path.Combine(networkPath, FullName);


            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
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
                                var RequestNum = worksheet.Cells[row, 1];
                                var Done = worksheet.Cells[row, 2];

                                // Check if any cells in the row are null
                                if (RequestNum.Value == null || Done.Value == null)
                                {
                                    return BadRequest($"Sorry , Some values are null in rows {row}. Please check the values equal null and update again.");
                                }
                                listupdate.Add(new UpdateMortg3
                                {
                                    RequestNumber = RequestNum.Value.ToString(),
                                    DoneReq = Convert.ToInt32(Done.Value)
                                });
                            }


                            foreach (var item in listupdate)
                            {
                                string reqnum = item.RequestNumber.ToString();
                                var ass = _context.Assignements
                                           .Where(s => s.Requestnumber == reqnum).ToList();

                                if (ass != null)
                                {
                                    foreach (var s in ass)
                                    {
                                        if (item.DoneReq != null)
                                        {
                                            s.Done = item.DoneReq;
                                        }
                                        else
                                        {
                                            return BadRequest("The value of (Done) column is empty , please check your Data again");
                                        }

                                    }
                                    await _context.SaveChangesAsync();

                                }
                            }
                            try
                            {
                                if (user != null)
                                {
                                    string hostName = Dns.GetHostName();
                                    var log = new ExcelUpdateLog
                                    {
                                        UserName = user.UserName,
                                        UpdatedAt = DateTime.Now,
                                        RecordsUpdated = rowCount - 1,
                                        FileContentpath = FilePath ,
                                        PcName = Dns.GetHostByName(hostName).AddressList[0].ToString()
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
        }

        [Authorize(Roles = ("teamleader,manger"))]
        [HttpPut("RE_ORDERS")]
        public async Task<ActionResult> update_Ship(IFormFile file)
        
        {
            var user = await _userManger.GetUserAsync(User);
            var networkPath = @"\\10.100.102.70\update_logs\Re_Orders";
            var listupdate = new List<UpdateMortg3>();


            if (file == null)
            {
                return BadRequest("Plz insert Excel File .. ");
            }
            if (!Path.GetExtension(file.FileName).Equals(".xlsx", System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Please make sure that the uploaded file is an Excel file (.xlsx) ");
            }
            if (!Directory.Exists(networkPath))
            {
                Directory.CreateDirectory(networkPath);
            }

            var FileName = Path.GetFileNameWithoutExtension(file.FileName);
            var File_Extenssion = Path.GetExtension(file.FileName);
            var FullName = FileName + File_Extenssion;
            var FilePath = Path.Combine(networkPath, FullName);


            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
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
                                var ShipID = worksheet.Cells[row, 1];
                                var Done = worksheet.Cells[row, 2];

                                // Check if any cells in the row are null
                                if (ShipID.Value == null || Done.Value == null)
                                {
                                    return BadRequest($"Sorry , Some values are null in rows {row}. Please check the values equal null and update again.");
                                }
                                listupdate.Add(new UpdateMortg3
                                {
                                    ShippingOrderID = Convert.ToInt32(ShipID.Value),
                                    Doneship = Convert.ToInt32(Done.Value)
                                });
                            }


                            foreach (var item in listupdate)
                            {
                                int shippingId = item.ShippingOrderID;
                                var ship = _context.ShippingordersStatuses
                                           .Where(s => s.IdShippingorder == shippingId).ToList();

                                if (ship != null)
                                {
                                    foreach (var sh in ship)
                                    {
                                        if (item.Doneship != null)
                                        {
                                            sh.Done = item.Doneship;
                                        }
                                        else
                                        {
                                            return BadRequest("The value of (Done) column is empty , please check your Data again");
                                        }

                                    }
                                    await _context.SaveChangesAsync();

                                }
                            }
                            try
                            {
                                if (user != null)
                                {
                                    string hostName = Dns.GetHostName();
                                    var log = new ExcelUpdateLog
                                    {
                                        UserName = user.UserName,
                                        UpdatedAt = DateTime.Now,
                                        RecordsUpdated = rowCount - 1,
                                        FileContentpath = FilePath ,
                                        PcName = Dns.GetHostByName(hostName).AddressList[0].ToString()
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
        }
    }
}
