using System;
using System.ComponentModel.DataAnnotations;

namespace RabbitBAU.Abstract
{
    public class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
