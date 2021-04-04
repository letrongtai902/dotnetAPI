using dotnetAPI.Model.DTO;
using dotnetAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnetAPI.Host.Extentions
{
    public static class EntityExtention
    {
        public static void UpdateCustomer(this Customer customer, CustomerDto customerDto)
        {
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.FullName = customer.FullName;
        }
    
    }
}