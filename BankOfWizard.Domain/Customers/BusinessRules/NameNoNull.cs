using BankOfWizard.Domain.BusinessRulesMesages;

namespace BankOfWizard.Domain.Customers.Rules
{
    public class NameNoNull : IBusinessRule
    {
        private readonly string _name;
        public NameNoNull(string name)
        {
            _name = name;
        }

        public string Message => ErrorMessages.NameNoNullMessage;

        public bool IsBroken() => _name == null;
    }
}
