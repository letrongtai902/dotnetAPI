using dotnetAPI.Model.DTO;
using dotnetAPI.Model.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Model.Validation
{
    public class CustomerValidation: AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(v => v.Email).EmailAddress().WithMessage("Sai cái Email");
            RuleFor(v => v.FullName).Length(2,50);
            RuleFor(v => v.ID).Empty();
           
        }
    }
}
