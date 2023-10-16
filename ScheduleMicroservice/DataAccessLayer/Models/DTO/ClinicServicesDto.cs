using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class ClinicServicesDto
    {
        public string? Id { get; set; }
        public string? ClinicName { get; set; }
        public string? ClinicAddress { get; set; }
        public List<string>? Services { get; set; }
    }
}
