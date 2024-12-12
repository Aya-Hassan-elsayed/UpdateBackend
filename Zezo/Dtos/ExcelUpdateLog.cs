using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Zezo.Dtos
{
    public class ExcelUpdateLog
    {
        [Key]
        public int id { get; set; }   

        public string  UserName { get; set; } 

        public DateTime UpdatedAt { get; set; }
        public int RecordsUpdated { get; set; }
        public string FileContentpath { get; set; } // New property to store the Excel file

        [MaxLength(150)]
        public string PcName { get; set; }


    }
}
