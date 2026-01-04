using Microsoft.AspNetCore.Mvc;
using WebApiAkademic.Controllers;

namespace WebApiAkademic.WebUtilities
{
    /// <summary>
    /// Class that holds utility methods to generate ProblemDetails responses for client-side errors.
    /// </summary>
    public static class ClientSideProblemDetailUtils
    {
        public static NotFoundObjectResult GenerateNotFoundForGetResult<T>(this IEntityControllerInfo entityInfo, T primaryKeyValue, string traceId, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = $"Cannot find the data with the specified id of [{entityInfo.FriendlyPKName}].",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Data of [{entityInfo.FriendlyTableName}] with primary key [{entityInfo.FriendlyPKName}] = {primaryKeyValue} is not found.",
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }
            problemDetails.Extensions["traceId"] = traceId;

            NotFoundObjectResult notFound = new NotFoundObjectResult(problemDetails);
            return notFound;
        }

        public static NotFoundObjectResult GenerateNotFoundForUpdateResult<T>(this IEntityControllerInfo entityInfo, T primaryKeyValue, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = $"Cannot update data. The Data with id of [{entityInfo.FriendlyPKName}] = {primaryKeyValue} not found.",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Cannot update data because Data of [{entityInfo.FriendlyTableName}] with primary key [{entityInfo.FriendlyPKName}] = {primaryKeyValue} is not found",
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }

            NotFoundObjectResult notFound = new NotFoundObjectResult(problemDetails);
            return notFound;
        }
        public static NotFoundObjectResult GenerateNotFoundForDeleteResult<T>(this IEntityControllerInfo entityInfo, T primaryKeyValue, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = $"Cannot delete data. The Data with id of [{entityInfo.FriendlyPKName}] = {primaryKeyValue} not found.",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Cannot delete data because Data of [{entityInfo.FriendlyTableName}] with primary key [{entityInfo.FriendlyPKName}] = {primaryKeyValue} is not found",
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }
            NotFoundObjectResult notFound = new NotFoundObjectResult(problemDetails);
            return notFound;
        }

        public static ConflictObjectResult GenerateConflictResult<T>(this IEntityControllerInfo entityInfo,T primaryKeyValue, string traceId, string? problemDetailType = null)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = $"Cannot add data. The Data with id of [{entityInfo.FriendlyPKName}] = {primaryKeyValue}",
                Status = StatusCodes.Status409Conflict,
                Detail = $"Cannot add data because data of [{entityInfo.FriendlyTableName}] with primary key [{entityInfo.FriendlyPKName}] = {primaryKeyValue} already exists."
            };
            if (!string.IsNullOrEmpty(problemDetailType))
            {
                problemDetails.Type = problemDetailType;
            }
            problemDetails.Extensions["traceId"] = traceId;

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
                Title = "Bad request caused by data error in request's parameter of data.",
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
