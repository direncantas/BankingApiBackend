using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

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

        public void Update(Account account)
        {
            var deletedAccount = _accounts.SingleOrDefault(x => x.AccountNumber == account.AccountNumber);
            _accounts.Remove(deletedAccount);
            _accounts.Add(account);
        }
    }
}
