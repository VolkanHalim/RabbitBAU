using RabbitBAU.Abstract;

namespace RabbitBAU.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {


        }
    }
}
