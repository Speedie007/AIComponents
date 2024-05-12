using AIComponents.Common.Errors;
using AIComponents.Common.Interfaces;

namespace AIComponents.Common.Result
{
    public abstract partial class BaseResult : IResult
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

        public List<BaseError> Errors { get; private set; } = new List<BaseError>();

        public virtual void LogResults()
        {
            if (Success)
            {
                Console.WriteLine($"NO - Errors Found: {GetType().Name} - YES");
                Console.WriteLine();
            }
            else
                foreach (var error in Errors)
                {
                    foreach (string errorMessage in error.AllErrorMessages)
                    {
                        Console.WriteLine($"Errors Found:Type-[{error.GetType().Name}]\nMessage:{errorMessage}");
                        Console.WriteLine();
                    }
                }
        }

        public virtual void SaveError(BaseError error)
        {
            Errors.Add(error);
        }
    }
}
