using AIComponents.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.Interfaces
{
    public partial interface IError
    {
        List<string> AllErrorMessages { get; }
        string ErrorType { get; }
        string GlobalErrorMessage { get; set; }

        void AddError(string errorMessage);
    }
}
