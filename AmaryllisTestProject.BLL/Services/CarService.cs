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
            var listCars = await _carRepository.GetAllAsync();
            var listCarDTOs = _mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(listCars);
            return listCarDTOs;
        }

        public async Task<CarDTO> GetByIdAsync(int id)
        {
            var car = await _carRepository.FindByIdAsync(id);
            var carDTO = _mapper.Map<Car, CarDTO>(car);
            return carDTO;
        }

        public async Task Update(CarDTO item)
        {
            var sourceCar = await _carRepository.FindByIdAsync(item.Id);

            if (sourceCar != null)
            {
                sourceCar.Brand = item.Brand;
                sourceCar.Class = item.Class;
                sourceCar.Model = item.Model;
                sourceCar.RegistrationNumber = item.RegistrationNumber;
                sourceCar.YearOfIssue = item.YearOfIssue;

                await _carRepository.UpdateAsync(sourceCar);
            }
            else throw new Exception("Такой записи нет");
        }
    }
}
