using System;

namespace RabbitBAU.Abstract
{
    public class Message : EntityBase
    {
        public DateTime SentDate { get; set; }
        public string Content { get; set; }
    }
}
