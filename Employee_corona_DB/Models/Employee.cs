using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Xunit;

namespace Employee_corona_DB.Models
{
    public class Employee
    {
        
       
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(9), MinLength(9)]
        [BsonId]
        public string IdentityCard { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter Mobile No")]
        [MaxLength(9), MinLength(9)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Please enter Mobile No")]
        [Phone]
        [MaxLength(10), MinLength(10)]
        [Key]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        [DataType(DataType.Date)]
        public DateTime[] CoronaVaccineDates { get; set; }
        public string[] CoronaVaccineManufacturers { get; set; }
        [DataType(DataType.Date)]
        public DateTime PositiveResultDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RecoveryDate { get; set; }
    }
}
