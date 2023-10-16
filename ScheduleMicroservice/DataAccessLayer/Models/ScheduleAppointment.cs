using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class ScheduleAppointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        [Required(ErrorMessage= "PatientName is required")]
        public required string PatientuserName { get; set; }
        [Required(ErrorMessage = "ClinicName is required")]
        public required string ClinicName { get; set; }
        [Required(ErrorMessage = "ClinicAddress is required")]
        public required string ClinicAddress { get; set; }
        [Required(ErrorMessage = "Service is required")]
        public required string Service { get; set; }
        [Required(ErrorMessage = "DateTimeOfVisit is required")]
        public DateTime DateTimeOfVisit { get; set; }

    }
}
