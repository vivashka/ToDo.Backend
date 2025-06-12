namespace ToDo.Shared.OperationResult;

public record ErrorActionResult(
    int ErrorCode,
    string ErrorMessage);