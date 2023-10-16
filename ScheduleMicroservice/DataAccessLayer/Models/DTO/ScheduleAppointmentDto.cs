using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class ScheduleAppointmentDto
    {
        public string? Id { get; set; }
        public string? PatientuserName { get; set; }
        public string? ClinicName { get; set; }
        public string? ClinicAddress { get; set; }
        public string? Service { get; set; }
        public DateTime DateTimeOfVisit { get; set; }
    }
}
