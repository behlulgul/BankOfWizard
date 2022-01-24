
using BankOfWizard.Domain.BusinessRulesMesages;

namespace BankOfWizard.Domain.Customers.Rules
{
    public class CountyNoNull : IBusinessRule
    {
        private readonly string _state;
        public CountyNoNull(string state)
        {
            _state = state;
        }

        public string Message => ErrorMessages.CountyNoNullMessage;

        public bool IsBroken() => _state == null;
    }
}
