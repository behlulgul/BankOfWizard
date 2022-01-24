using BankOfWizard.Domain.BusinessRulesMesages;


namespace BankOfWizard.Domain.Customers.Rules
{
    public class PhoneNumberNoNull : IBusinessRule
    {
        private readonly string _phone;
        public PhoneNumberNoNull(string phone)
        {
            _phone = phone;
        }

        public string Message => ErrorMessages.PhoneNoNoNullMessage;

        public bool IsBroken() => _phone == null;
    }
}
