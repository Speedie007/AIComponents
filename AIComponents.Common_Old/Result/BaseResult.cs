using AIComponents.Common.Errors;
using AIComponents.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.Result
{
    public partial class BaseResult : IResult 
    {
        #region Cstor
        public BaseResult()
        {
            Errors = new List<BaseError>();
        }
        #endregion
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        public List<BaseError> Errors { get; set; }

        public void LogResults()
        {
            throw new NotImplementedException();
        }

        public void SaveError(BaseError error)
        {
            Errors.Add(error);
        }
    }
}
