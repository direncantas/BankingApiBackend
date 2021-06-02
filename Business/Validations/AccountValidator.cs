using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Linq;

namespace Business.Validations
{
    public class AccountValidator : AbstractValidator<Account>
    {
        private readonly IAccountDal _accountDal;
        public AccountValidator(IAccountDal accountDal)
        {
            _accountDal = accountDal;

            RuleFor(x => x.AccountNumber).Must(MustBeUnique).WithMessage("Account Number must be unique.");
            RuleFor(x => x.CurrencyCode).Must(CurrencyCode).WithMessage("Currency Code must be 'TRY' , 'USD' or 'EUR'.");
        }

        private bool MustBeUnique(int accountNumber)
        {
            if (_accountDal.GetAll().Any(x => x.AccountNumber == accountNumber))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CurrencyCode(string currencyCode)
        {
            string code = currencyCode.ToUpper();

            if (code == "TRY" || code == "USD" || code == "EUR")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
