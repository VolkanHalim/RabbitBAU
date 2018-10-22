using System;

namespace RabbitBAU.Domain
{
    public class Message
    {
        public DateTime SentDate { get; set; }
        public string Content { get; set; }
    }
}
