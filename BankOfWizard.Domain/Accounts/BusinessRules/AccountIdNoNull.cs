using BankOfWizard.Domain.BusinessRulesMesages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfWizard.Domain.Accounts.Rules
{
    public class AccountIdNoNull : IBusinessRule
    {
        private readonly Guid _id;
        public AccountIdNoNull(Guid id)
        {
            _id = id;
        }

        public string Message => ErrorMessages.AccountIdNoNull;

        public bool IsBroken() => _id == Guid.Empty;
    }
}
