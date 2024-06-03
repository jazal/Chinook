using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Chinook.Pages;
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string? ErrorMessage { get; set; } = "An unexpected error occurred.";

    public string? ErrorDetail { get; set; }

    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(string? message, string? detail)
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        if (!string.IsNullOrEmpty(message))
        {
            ErrorMessage = message;
        }

        if (!string.IsNullOrEmpty(detail))
        {
            ErrorDetail = detail;
        }
    }
}
