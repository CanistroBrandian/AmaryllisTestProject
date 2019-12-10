using AmaryllisTestProject.DAL.EF;
using AmaryllisTestProject.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Concrate
{
    public class UnitOfWork : IUnitOfWork
    {
        public EFContext Context { get; }

        public UnitOfWork(EFContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
