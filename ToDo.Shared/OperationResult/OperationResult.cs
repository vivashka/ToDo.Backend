namespace ToDo.Shared.OperationResult;

public class OperationResult<T>
{
    public bool IsSuccess { get; }
    
    public T? Data { get; }
    
    public ErrorActionResult? Error { get; }

    public static OperationResult<T> Success(T value) => new(true, value, null);
    public static OperationResult<T> Failure(ErrorActionResult error) => new(false, default, error);
    
    public OperationResult(bool isSuccess, T? value, ErrorActionResult? errorMessage)
    {
        IsSuccess = isSuccess;
        Data = value;
        Error = errorMessage;
    }
}