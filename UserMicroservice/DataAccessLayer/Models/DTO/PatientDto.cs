using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTO
{
    public class PatientDto
    {
        public  string? Id { get; set; }
        public  string? FirstName { get; set; }       
        public  string? LastName { get; set; }
        public  string? Email { get; set; }       
        public  string? UserName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/DD/YYYY}")]
        public  DateTime? DateOfBirth { get; set; }      
        public  string? Gender { get; set; }
        public  string? PhoneNumber { get; set; }
    }
}
