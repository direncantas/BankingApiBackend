using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.Validations
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        private readonly IAccountDal _accountDal;
        public TransactionValidator(IAccountDal accountDal)
        {
            _accountDal = accountDal;

            RuleFor(x => new { x.Amount, x.SenderAccountNumber }).Must(m => IsBalanceOk(m.Amount, m.SenderAccountNumber)).WithMessage("Insufficient balance error");
            RuleFor(x => new { x.SenderAccountNumber, x.ReceiverAccountNumber }).Must(m => SameCurrencyCode(m.SenderAccountNumber, m.ReceiverAccountNumber)).WithMessage("Both sender and receiver accounts should have the same currency code.");
        }

        private bool SameCurrencyCode(int senderAccountNumber , int receiverAccountNumber)
        {
            var sender = _accountDal.GetAll().SingleOrDefault(x => x.AccountNumber == senderAccountNumber);
            var receiver = _accountDal.GetAll().SingleOrDefault(x => x.AccountNumber == receiverAccountNumber);
            if (sender.CurrencyCode == receiver.CurrencyCode)
            {
                return true;
            }
            return false;
        }

        private bool IsBalanceOk(decimal amount , int senderAccountNumber)
        {
            var sender = _accountDal.GetAll().SingleOrDefault(x => x.AccountNumber == senderAccountNumber);

            if (sender.Balance >= amount)
            {
                return true;
            }
            return false;
        }

    }
}
