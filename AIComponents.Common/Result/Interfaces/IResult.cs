using AIComponents.Common.Errors;

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
