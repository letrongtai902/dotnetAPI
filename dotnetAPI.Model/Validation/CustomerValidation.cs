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
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Nhập đùng format Email")
                .NotNull().WithMessage("Email không được để trống");
            RuleFor(v => v.FullName).Length(2,50);
        }
    }
}
