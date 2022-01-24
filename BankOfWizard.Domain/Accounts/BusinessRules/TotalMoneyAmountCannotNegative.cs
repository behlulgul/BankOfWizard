using BankOfWizard.Domain.BusinessRulesMesages;


namespace BankOfWizard.Domain.Accounts.Rules
{
    public class TotalMoneyAmountCannotNegative : IBusinessRule
    {
        private readonly decimal _amountOfMoney;
        public TotalMoneyAmountCannotNegative(decimal amountOfMoney)
        {
            _amountOfMoney = amountOfMoney;
        }

        public string Message => ErrorMessages.TotalMoneyAmountCannotNegative;

        public bool IsBroken() => _amountOfMoney < 0;
    }
}
