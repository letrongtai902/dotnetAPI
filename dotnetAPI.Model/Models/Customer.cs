using dotnetAPI.Model.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace dotnetAPI.Model.Models
{
    [Validator(typeof(CustomerValidation))]
    public class Customer
    {
        [Key]
        public long ID { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

    }
}
