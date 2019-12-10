using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Repositories
{
    public class CarRepository : CommonRepository<Car>, ICarRepository
    {
        public CarRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
