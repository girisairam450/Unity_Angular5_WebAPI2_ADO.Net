namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class InvalidParameterValueException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.InvalidParameterValue;

        public InvalidParameterValueException() : base(InternalExceptionCode)
        {
        }

        public InvalidParameterValueException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}