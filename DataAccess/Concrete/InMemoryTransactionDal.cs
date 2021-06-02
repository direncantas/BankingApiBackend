using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class InMemoryTransactionDal : ITransactionDal
    {
        List<Transaction> _transactions = new List<Transaction>();
        public void Create(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public List<Transaction> GetAll()
        {
            return _transactions;
        }
    }
}
