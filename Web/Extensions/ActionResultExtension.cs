using System.Collections;
using Core.OperationResults;
using Microsoft.AspNetCore.Mvc;
using Web.Errors;

namespace Web.Extensions;

/// <summary>
/// Provides extension methods for converting operation results to <see cref="ActionResult"/> instances.
/// </summary>
public static class ActionResultExtension
{
    /// <summary>
    /// Converts a <see cref="NoDataResponse"/> to an appropriate <see cref="ActionResult"/>.
    /// </summary>
    /// <param name="controller">The controller instance.</param>
    /// <param name="noDataResponse">The response containing status code and message.</param>
    /// <returns>An <see cref="ActionResult"/> representing the response.</returns>
    public static ActionResult ToActionResult(this ControllerBase controller, NoDataResponse? noDataResponse)
    {
        if (noDataResponse != null)
        {
            var statusCode = noDataResponse.StatusCode;
            var message = noDataResponse.Message;

            if (statusCode == 404)
            {
                return controller.NotFound(new ApiResponse(statusCode, message));
            }

            if (statusCode == 400)
            {
                return controller.BadRequest(new ApiResponse(statusCode, message));
            }

            if (statusCode == 409)
            {
                return controller.Conflict(new ApiResponse(statusCode, message));
            }

            return controller.StatusCode(statusCode, new ApiResponse(statusCode, message));
        }

        return controller.NoContent();
    }

    /// <summary>
    /// Converts data and an optional message to an appropriate <see cref="ActionResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    /// <param name="controller">The controller instance.</param>
    /// <param name="data">The data to be included in the response.</param>
    /// <param name="message">An optional message to include in the response.</param>
    /// <returns>An <see cref="ActionResult{T}"/> representing the response.</returns>
    public static ActionResult<T> ToActionResult<T>(this ControllerBase controller, T? data, string? message = null)
    {
        if (data == null || EqualityComparer<T>.Default.Equals(data, default))
        {
            return controller.NoContent();
        }

        if (data is Result result)
        {
            return result.NoDataResponse != null
                ? controller.ToActionResult(result.NoDataResponse)
                : controller.Ok();
        }

        if (data is IEnumerable enumerable && data is not string)
        {
            var enumerator = enumerable.GetEnumerator();
            try
            {
                if (!enumerator.MoveNext())
                {
                    return controller.Ok(new ApiResponse(200, message ?? "No data found"));
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        return controller.Ok(data);
    }

    /// <summary>
    /// Returns a NoContent <see cref="ActionResult"/>.
    /// </summary>
    /// <param name="controller">The controller instance.</param>
    /// <returns>An <see cref="ActionResult"/> representing a NoContent response.</returns>
    public static ActionResult ToActionResult(this ControllerBase controller)
    {
        return controller.NoContent();
    }
}