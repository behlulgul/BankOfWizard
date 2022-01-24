using MethodBoundaryAspect.Fody.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfWizard.App.Common
{
    public sealed class Logging : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            //Log info about method starting

        }

        public override void OnExit(MethodExecutionArgs args)
        {
            //Log info about method ending
        }

        public override void OnException(MethodExecutionArgs args)
        {
            //Catch unexcepted exception
            //Log info about method exception
        }

    }
}
