using Business.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IDataResult<List<Account>> GetAll();
        IResult Create(Account account);
    }
}
