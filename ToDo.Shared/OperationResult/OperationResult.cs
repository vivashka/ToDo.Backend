namespace ToDo.Shared.OperationResult;

public class OperationResult<T>
{
    public bool IsSuccess { get; }
    
    public T? Value { get; }
    
    public (int, string)? ErrorMessage { get; }

    public static OperationResult<T> Success(T value) => new(true, value, null);
    public static OperationResult<T> Failure((int, string) error) => new(false, default, error);
    
    public OperationResult(bool isSuccess, T? value, (int, string)? errorMessage)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
    }
}