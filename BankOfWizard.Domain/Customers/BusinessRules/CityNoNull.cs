
using BankOfWizard.Domain.BusinessRulesMesages;

namespace BankOfWizard.Domain.Customers.Rules
{
    public class CityNoNull : IBusinessRule
    {
        private readonly string _city;
        public CityNoNull(string city)
        {
            _city = city;
        }

        public string Message => ErrorMessages.CityNoNullMessage;

        public bool IsBroken() => _city == null;
    }
}
