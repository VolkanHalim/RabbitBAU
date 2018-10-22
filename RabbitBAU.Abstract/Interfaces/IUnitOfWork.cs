using System;

namespace RabbitBAU.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;

        int SaveChanges();
    }
}
