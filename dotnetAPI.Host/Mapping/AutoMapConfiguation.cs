using AutoMapper;
using dotnetAPI.Model.DTO;
using dotnetAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnetAPI.Host.Mapping
{
    public class AutoMapConfiguation
    {
        public static void configure()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
           
        }
    }
}