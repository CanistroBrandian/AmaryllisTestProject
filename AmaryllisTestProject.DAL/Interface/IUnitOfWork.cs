using AmaryllisTestProject.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmaryllisTestProject.DAL.Interface
{
   public interface IUnitOfWork : IDisposable
    {
        EFContext Context { get; }
        Task CommitAsync();
    }
    
}
