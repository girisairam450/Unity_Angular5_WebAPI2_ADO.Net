using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public abstract class BusinessException : Exception
    {
        protected BusinessException()
        {
        }

        public static readonly Dictionary<BusinessExceptionCode, string> BusinessExceptionMessages = new Dictionary<BusinessExceptionCode, string>
        {
            { BusinessExceptionCode.Unknown, "Unknown exception" },
            { BusinessExceptionCode.Unauthorized, "Unauthorized access" },
            { BusinessExceptionCode.OAuthVerification, "OAuth verification failed" },
            { BusinessExceptionCode.ParameterIsRequired, "Parameter is required" },
            { BusinessExceptionCode.RestServiceError, "Bad result of REST service call" },
            { BusinessExceptionCode.RestServiceDeserializationError, "REST service deserialization error" },
            { BusinessExceptionCode.PeopleService, "People service error" },
            { BusinessExceptionCode.InvalidHttpRequestContentType, "Invalid ContentType of http request data" },
            { BusinessExceptionCode.InvalidDataBaseVersion, "Invalid version of database" },
            { BusinessExceptionCode.InvalidFileSize, "Invalid size of file" },
            { BusinessExceptionCode.InvalidFileExtension, "Invalid extension of file" },
            { BusinessExceptionCode.InvalidFileContent, "File contains an invalid content" },
            { BusinessExceptionCode.SqlUnknown, "Unknown sql exception" },
            { BusinessExceptionCode.EntityNotFound, "Entity not found" },
            { BusinessExceptionCode.EntityDetailsNotFound, "Entity details not found" },
            { BusinessExceptionCode.EntityAlreadyExists, "Entity already exists" },
            { BusinessExceptionCode.DependedEntityExists, "Depended entity exists" },
            { BusinessExceptionCode.InvalidParameterValue, "Invalid parameter value" },
            { BusinessExceptionCode.SurveyQuestionModification, "Survey Has Employee Answers. Can't update questions and/or answers" },
            { BusinessExceptionCode.PermissionDenied, "Permission denied" },
            { BusinessExceptionCode.FileAlreadyExist,"Uploaded file already exists"}
        };

        private readonly string errorMessage;

        private string fullMessage;

        protected BusinessException(BusinessExceptionCode exceptionCode)
        {
            ExceptionCode = exceptionCode;
            BusinessExceptionMessages.TryGetValue(exceptionCode, out errorMessage);
        }

        protected BusinessException(BusinessExceptionCode exceptionCode, string message)
        {
            ExceptionCode = exceptionCode;
            BusinessExceptionMessages.TryGetValue(exceptionCode, out errorMessage);

            if (!string.IsNullOrWhiteSpace(message))
            {
                fullMessage = message;
            }
        }

        public BusinessExceptionCode ExceptionCode { get; }

        public override string Message => errorMessage;

        public string FullMessage
        {
            get { return string.IsNullOrWhiteSpace(fullMessage) ? errorMessage : fullMessage; }
            set { fullMessage = value; }
        }

        public object ExceptionData { get; set; }
    }
}
