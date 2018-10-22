using Microsoft.EntityFrameworkCore;
using RabbitBAU.Abstract;

namespace RabbitBAU.Business
{

    //TODO:Inheritance nedir?
    public class SendMessage : EFUnitOfWork<bool>
    {
        public SendMessage(IUserRepository _userRepository, IMessageRepository _messageRepository, DbContext dbContext) : base(dbContext)
        {
            userRepository = _userRepository;

            messageRepository = _messageRepository;
        }

        private IUserRepository userRepository;

        private IMessageRepository messageRepository;

        public override void Run()
        {

        }
    }
}
