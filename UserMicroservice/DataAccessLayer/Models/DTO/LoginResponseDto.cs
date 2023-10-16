using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class LoginResponseDto
    {
        public string? id { get; set; }
        [EmailAddress]
        public string? email { get; set; }
        public string? token { get; set; }
        public string? userName { get; set; }
    }
}
