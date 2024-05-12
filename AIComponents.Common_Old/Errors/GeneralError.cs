using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.Errors
{
    public partial class GeneralError : BaseError
    {
        public GeneralError()
        {
        }

        public GeneralError(List<string> errorMessages) : base(errorMessages)
        {
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
