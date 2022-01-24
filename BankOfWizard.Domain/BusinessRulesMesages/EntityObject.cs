using System;

namespace BankOfWizard.Domain.BusinessRulesMesages
{
    public abstract class EntityObject
    {
        public Guid Id { get; set; }
        protected static void CheckBusinessRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

    }
}
