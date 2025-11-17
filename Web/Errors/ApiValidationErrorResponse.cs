using Microsoft.AspNetCore.Mvc;

namespace Web.Errors;

/// <summary>
/// Represents a validation error response for API requests. Inherits from <see cref="ApiResponse"/>.
/// </summary>
public class ApiValidationErrorResponse : ApiResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiValidationErrorResponse"/> class with the specified validation
    /// errors.
    /// </summary>
    /// <param name="errors">A collection of validation error messages.</param>
    public ApiValidationErrorResponse(IEnumerable<string> errors) : base(400)
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets or sets the collection of validation error messages.
    /// </summary>
    public IEnumerable<string> Errors { get; set; }

    /// <summary>
    /// Generates a validation error response based on the provided action context.
    /// </summary>
    /// <param name="context">The action context containing model state information.</param>
    /// <returns>An <see cref="IActionResult"/> representing the validation error response.</returns>
    public static IActionResult GenerateErrorResponse(ActionContext context)
    {
        var data = context.ModelState.Where(x => x.Value?.Errors != null && x.Value.Errors.Any());
        var errorMessages = data.SelectMany(x =>
            x.Value?.Errors.Select(error => error.ErrorMessage) ?? Enumerable.Empty<string>());

        var response = new ApiValidationErrorResponse(errorMessages);

        return new BadRequestObjectResult(response);
    }
}