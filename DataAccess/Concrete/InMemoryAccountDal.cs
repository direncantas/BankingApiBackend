using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class InMemoryAccountDal : IAccountDal
    {
        List<Account> _accounts = new List<Account>();
        public void Create(Account account)
        {
            _accounts.Add(account);
        }

        public List<Account> GetAll()
        {
            return _accounts;
        }
    }
}
