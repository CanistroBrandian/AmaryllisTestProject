using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmaryllisTestProject.BLL.Interfaces
{
    public interface IOrderService 
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(int id);
        Task UpdateAsync(OrderDTO item);
        Task DeleteAsync(int id);
        Task CreateAsync(OrderDTO item);
        Task<IEnumerable<OrderDTO>> GetAllAsync(DateTime? startDate = null, DateTime? finishedDate = null, string userFirstName = null, string userLastName = null);
    }
}
