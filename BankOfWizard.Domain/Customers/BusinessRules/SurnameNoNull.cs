using BankOfWizard.Domain.BusinessRulesMesages;

namespace BankOfWizard.Domain.Customers.Rules
{
    public class SurnameNoNull : IBusinessRule
    {
        private readonly string _surname;
        public SurnameNoNull(string name)
        {
            _surname = name;
        }

        public string Message => ErrorMessages.SurnameNoNullMessage;

        public bool IsBroken() => _surname == null;
    }
}
