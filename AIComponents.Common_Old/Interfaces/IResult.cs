using AIComponents.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.Interfaces
{
    public interface IResult 
    {
        bool Success { get; }
        List<BaseError> Errors { get; }

        void SaveError(BaseError error);
        void LogResults();
    }
}
