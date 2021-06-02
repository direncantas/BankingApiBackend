using Business.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        IDataResult<List<Transaction>> GetAll();
        IResult Create(Transaction transaction);
    }
}
