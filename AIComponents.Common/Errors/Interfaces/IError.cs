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
