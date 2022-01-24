
namespace BankOfWizard.Domain.BusinessRulesMesages
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
