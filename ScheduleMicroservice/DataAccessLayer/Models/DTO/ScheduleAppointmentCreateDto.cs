using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class ScheduleAppointmentCreateDto
    {
        public required string PatientuserName { get; set; }
        public required string ClinicName { get; set; }
        public required string ClinicAddress { get; set; }
        public required string Service { get; set; }
        public DateTime DateTimeOfVisit { get; set; }
    }
}
