using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class LoginRequestDto
    {
        public required string userName { get; set; }
        public required string password { get; set; }
    }
}
