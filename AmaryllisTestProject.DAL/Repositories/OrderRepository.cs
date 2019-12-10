using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Repositories
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
