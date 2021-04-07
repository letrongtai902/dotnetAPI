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
            RuleFor(v => v.FullName)
                .Length(2,50);
            RuleFor(v => v.PhoneNumber)
                .Length(8,12).WithMessage("độ dài sđt từ 8 đến 12 chữa số")
                .Must(x => int.TryParse(x, out var val) && val > 0).WithMessage("Đừng nhập ký tự vào số điện thoại");
            RuleFor(v => v.ID)
                .LessThan(Int64.MaxValue)
                .GreaterThan(0)
                .NotEmpty()
                .WithMessage("ID Không được trống");
        }
    }
}
