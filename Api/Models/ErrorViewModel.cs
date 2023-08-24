namespace Api.Models;

public record ErrorViewModel(string RequestId, string ErrorMessage)
{
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
