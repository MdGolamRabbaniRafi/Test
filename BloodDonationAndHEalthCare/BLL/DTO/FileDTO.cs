using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class FileDTO
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer")]
        public int UserId { get; set; }

        public string UserType { get; set; }


    }
}
