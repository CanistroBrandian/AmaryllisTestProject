using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Repositories
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
