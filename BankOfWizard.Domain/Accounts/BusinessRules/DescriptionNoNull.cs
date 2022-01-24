using BankOfWizard.Domain.BusinessRulesMesages;


namespace BankOfWizard.Domain.Accounts.Rules
{
    public class DescriptionNoNull : IBusinessRule
    {
        private readonly string _description;
        public DescriptionNoNull(string description)
        {
            _description = description;
        }

        public string Message => ErrorMessages.DescriptionNoNull;

        public bool IsBroken() => _description == null;
    }
}
