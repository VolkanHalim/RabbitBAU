using System;

namespace RabbitBAU.Abstract
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
