using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmaryllisTestProject.BLL.Interfaces
{
   public interface IUserService 
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task UpdateAsync(UserDTO item);
        Task DeleteAsync(int id);
        Task<UserDTO> CreateAsync(UserDTO item);
    }
}
