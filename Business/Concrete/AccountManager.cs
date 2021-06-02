using Business.Abstract;
using Business.Results;
using Business.Validations;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IResult Create(Account account)
        {
            AccountValidator validator = new AccountValidator(_accountDal);
            var result = validator.Validate(account);
            if (result.IsValid)
            {
                _accountDal.Create(account);
                return new SuccessResult("Account is Created!");
            }
            else
            {
                var message = "";
                foreach (var error in result.Errors)
                {
                    message += error;
                }
                return new ErrorResult(message);
            }
        }

        public IDataResult<List<Account>> GetAll()
        {
            return new SuccessDataResult<List<Account>>(_accountDal.GetAll() , "Accounts are listed!");
        }
    }
}
