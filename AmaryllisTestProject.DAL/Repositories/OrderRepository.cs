using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmaryllisTestProject.DAL.Repositories
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _uow.Context.Set<Order>().Include(e => e.Car).AsNoTracking().ToListAsync();
        }
    }
}
