using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class ClinicServicesCreateDto
    {       
        public required string ClinicName { get; set; }     
        public required string ClinicAddress { get; set; }     
        public required List<string> Services { get; set; }
    }
}
