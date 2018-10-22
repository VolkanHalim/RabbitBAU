using RabbitBAU.Abstract;

namespace RabbitBAU.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
