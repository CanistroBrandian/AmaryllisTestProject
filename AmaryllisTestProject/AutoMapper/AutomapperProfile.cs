using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.DAL.Entities;
using AutoMapper;

namespace AmaryllisTestProject.AutoMapper
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
