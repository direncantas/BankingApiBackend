using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        public void Update(Account account);
    }
}
