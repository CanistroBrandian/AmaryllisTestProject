using AmaryllisTestProject.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Interface
{
   public interface IUnitOfWork : IDisposable
    {
        EFContext Context { get; }
        void Commit();
    }
    
}
