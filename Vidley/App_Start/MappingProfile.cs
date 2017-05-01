using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.DTOs;
using Vidley.Models;

namespace Vidley.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer,CustomerDTO>();

            Mapper.CreateMap<CustomerDTO,Customer>();
        }
    }
}