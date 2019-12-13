using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmaryllisTestProject.DAL.Repositories
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public override async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _uow.Context.Set<Order>().Include(e => e.Car).Include(u => u.User).AsNoTracking().ToListAsync();
            }
            return await _uow.Context.Set<Order>().Where(predicate).Include(e => e.Car).Include(u => u.User).AsNoTracking().ToListAsync();
        }

        public override async Task<Order> FindByIdAsync(int id)
        {
            return await _uow.Context.Set<Order>().Include(e => e.Car).Include(u => u.User).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
