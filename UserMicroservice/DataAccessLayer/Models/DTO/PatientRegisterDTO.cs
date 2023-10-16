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
    public class PatientRegisterDto
    {
        public required string FirstName { get; set; }       
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }       
        public required string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        //[StringLength(15, MinimumLength = 8, ErrorMessage = "Password length should be minimum 8 and maximum 15 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+=\[{\]};:<>|./?,-]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain atleast one uppercase,lowercase,number and special character.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password  is required")]
        //[StringLength(15, MinimumLength = 8, ErrorMessage = "Confirm Password length should be minimum 8 and maximum 15 characters")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = " Password and Confirm password should match")]
        public required string Confirm_Password { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/DD/YYYY}")]
        public  DateTime DateOfBirth { get; set; }      
        public required string Gender { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
