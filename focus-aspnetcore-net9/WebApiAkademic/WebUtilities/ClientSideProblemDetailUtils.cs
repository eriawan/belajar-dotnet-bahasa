using Microsoft.AspNetCore.Mvc;

namespace WebApiAkademic.WebUtilities
{
    /// <summary>
    /// Class that holds utility methods to generate ProblemDetails responses for client-side errors.
    /// </summary>
    public class ClientSideProblemDetailUtils
    {
        public static NotFoundObjectResult GenerateNotFoundForGetResult<T>(T primaryKeyValue, string primaryKeyName, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Data with primary key [{primaryKeyName}] = {primaryKeyValue} not found.",
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }

            NotFoundObjectResult notFound = new NotFoundObjectResult(problemDetails);
            return notFound;
        }

        public static NotFoundObjectResult GenerateNotFoundForUpdateResult<T>(T primaryKeyValue, string primaryKeyName, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Cannot update data. The Data with primary key [{primaryKeyName}] = {primaryKeyValue} not found.",
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }

            NotFoundObjectResult notFound = new NotFoundObjectResult(problemDetails);
            return notFound;
        }

        public static ConflictObjectResult GenerateConflictResult<T>(T primaryKeyValue, string primaryKeyName, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "",
                Status = StatusCodes.Status409Conflict,
                Detail = $"Data with primary key [{primaryKeyName}] = {primaryKeyValue} already exists."
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }
            ConflictObjectResult conflict = new ConflictObjectResult(problemDetails);
            return conflict;
        }

        public static BadRequestObjectResult GenerateBadRequestResult<T>(List<string> parameterErrors, string? problemDetailType = null)
        {
            string combinedDataParameterErrors = "";
            foreach (var item in parameterErrors)
            {
                combinedDataParameterErrors += item + ";";
            }
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "Bad request caused by data error in request",
                Status = StatusCodes.Status400BadRequest,
                Detail = $"Bad request caused by data error in the request: {combinedDataParameterErrors}"
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }
            BadRequestObjectResult badRequest = new BadRequestObjectResult(problemDetails);
            return badRequest;
        }
    }
}
