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
    public class UserService :IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserDTO item)
        {
            if (item != null)
            {
                var user = _mapper.Map<UserDTO, User>(item);
                await _userRepository.CreateAsync(user);
            }
            else throw new Exception("Данные не заполнены");
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var listUsers = await _userRepository.GetAllAsync();
            var listUserDTOs = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(listUsers);
            return listUserDTOs;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public async Task Update(UserDTO item)
        {
            var sourceUser = await _userRepository.FindByIdAsync(item.Id);

            if (sourceUser != null)
            {
                sourceUser.LastName = item.LastName;
                sourceUser.FirstName = item.FirstName;
                sourceUser.DateOfBirth = item.DateOfBirth;
                sourceUser.DriveNumber = item.DriveNumber;
                _userRepository.Update(sourceUser);
            }
            else throw new Exception("Такой записи нет");
        }
    }
}
