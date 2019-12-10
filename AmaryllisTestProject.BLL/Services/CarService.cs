using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.BLL.Interfaces;
using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmaryllisTestProject.BLL.Services
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;

        }

        public async Task CreateAsync(CarDTO item)
        {
            if (item != null)
            {
                var car = _mapper.Map<CarDTO, Car>(item);
                await _carRepository.CreateAsync(car);
            }
            else throw new Exception("Данные не заполнены");
        }

        public async Task DeleteAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            var listProducts = await _carRepository.GetAllAsync();
            var listProductDTOs = _mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(listProducts);
            return listProductDTOs;
        }

        public Task<CarDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CarDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
