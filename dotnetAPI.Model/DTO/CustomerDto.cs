using dotnetAPI.Model.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Model.DTO
{
    [Validator(typeof(CustomerValidation))]
    public class CustomerDto
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
