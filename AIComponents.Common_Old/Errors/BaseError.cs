using AIComponents.Common.Interfaces;

namespace AIComponents.Common.Errors
{
    public abstract class BaseError : IError
    {
        #region Global Variables
        private string _errorMessage = "Error Undefined";

        #endregion

        #region Cstor
        protected BaseError()
        {
            AllErrorMessages = new List<string>();
        }
        protected BaseError(List<string> errorMessages)
        {
            AllErrorMessages = new List<string>(errorMessages);
        }
        #endregion

        #region Properties
        public string ErrorType
        {
            get
            {
                return GetType().Name;
            }
        }

        public List<string> AllErrorMessages { get; private set; }

        public string GlobalErrorMessage
        {
            get { return $"{ErrorType} - {_errorMessage}"; }
            set { _errorMessage = $"{ErrorType} - {value}"; }
        }

        #endregion

        #region Methods
        public void AddError(string errorMessage)
        {
            AllErrorMessages.Add(errorMessage);
        }
        #endregion

    }
}
