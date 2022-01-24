using BankOfWizard.Domain.BusinessRulesMesages;


namespace BankOfWizard.Domain.Customers.Rules
{
   
    public class CustomerNumberLengthIs4 : IBusinessRule
    {
        private readonly string _idN;
        public CustomerNumberLengthIs4(string idNo)
        {
            _idN = idNo;
        }

        public string Message => ErrorMessages.CustomerNumberLengthIs4;

        public bool IsBroken() => _idN.Length != 4;
    }
}
