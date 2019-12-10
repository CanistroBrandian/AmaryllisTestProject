using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.BLL.AutoMapper
{
   public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, UserDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
        }

    }
}
