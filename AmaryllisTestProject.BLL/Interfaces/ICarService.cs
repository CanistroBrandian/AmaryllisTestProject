using AmaryllisTestProject.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmaryllisTestProject.BLL.Interfaces
{
    public interface ICarService 
    {
        Task<IEnumerable<CarDTO>> GetAllAsync();
        Task<CarDTO> GetByIdAsync(int id);
        Task Update(CarDTO item);
        Task DeleteAsync(int id);
        Task CreateAsync(CarDTO item);
    }
}
