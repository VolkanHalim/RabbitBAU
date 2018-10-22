using Microsoft.EntityFrameworkCore;
using System;

namespace RabbitBAU.Abstract
{
    //TODO:UnitOfWork pattern enterprise uygulamalarda çok önemlidir. nedir, ne işe yarar araştırın.
    public abstract class EFUnitOfWork<X> : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public abstract void Run();
        //TODO:Generic Types konusunu araştırın...
        public TransactionResult<X> Result;

        public EFUnitOfWork(DbContext dbContext)
        {
            //TODO:Çift soru işareti nedir, araştırın.
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext can not be null.");

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            return new Repository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {

                return _dbContext.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }
        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);

            //TODO: GarbageCollector araştırın
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
