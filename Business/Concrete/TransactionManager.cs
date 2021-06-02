using Business.Abstract;
using Business.Results;
using Business.Validations;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly ITransactionDal _transactionDal;
        private readonly IAccountDal _accountDal;

        public TransactionManager(ITransactionDal transactionDal , IAccountDal accountDal)
        {
            _transactionDal = transactionDal;
            _accountDal = accountDal;
        }

        public IResult Create(Transaction transaction)
        {
            var sender = _accountDal.GetAll().SingleOrDefault(x => x.AccountNumber == transaction.SenderAccountNumber);
            var receiver = _accountDal.GetAll().SingleOrDefault(x => x.AccountNumber == transaction.ReceiverAccountNumber);

            if (sender == null)
            {
                return new ErrorResult("Invalid sender account number");
            }

            if (receiver == null)
            {
                return new ErrorResult("Invalid receiver account number");
            }


            TransactionValidator validator = new TransactionValidator(_accountDal);
            var result = validator.Validate(transaction);

            if (result.IsValid)
            {
                _transactionDal.Create(transaction);
                sender.Balance -= transaction.Amount;
                receiver.Balance += transaction.Amount;
                return new SuccessResult("Money Transaction is created!");
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

        public IDataResult<List<Transaction>> GetAll()
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll() , "Money Transactions are listed!");
        }
    }
}
