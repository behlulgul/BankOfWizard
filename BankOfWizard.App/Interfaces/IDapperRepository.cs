using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfWizard.App.Interfaces
{
    public interface IDapperRepository
    {
        IDbConnection Connection { get; }
        void Dispose();
    }
}
