using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.WEB.Models;
using AutoMapper;

namespace AmaryllisTestProject.AutoMapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<CarDTO, CarModel>().ReverseMap();
            CreateMap<OrderDTO, OrderModel>().ReverseMap();
            CreateMap<UserDTO, UserModel>().ReverseMap();
        }

    }
}
