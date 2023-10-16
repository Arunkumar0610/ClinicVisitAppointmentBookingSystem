using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(20,MinimumLength =5,ErrorMessage = "FirstName length should be minimum 5 and maximum 20 characters")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "LastName length should be minimum 5 and maximum 20 characters")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email is invalid")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        //[StringLength(15, MinimumLength = 8, ErrorMessage = "Password length should be minimum 8 and maximum 15 characters")]
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+=;:<>|./?,-]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain atleast one uppercase,lowercase,number and special character.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password  is required")]
        //[StringLength(15, MinimumLength = 8, ErrorMessage = "Confirm Password length should be minimum 8 and maximum 15 characters")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = " Password and Confirm password should match")]
        public required string Confirm_Password { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true,DataFormatString ="{0:MM/DD/YYYY}")]
        public required DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public required string Gender { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        public required string PhoneNumber { get; set; }

    }
}
