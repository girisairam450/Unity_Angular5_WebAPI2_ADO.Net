namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class SqlUnknownException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.SqlUnknown;

        public SqlUnknownException() : base(InternalExceptionCode)
        {
        }

        public SqlUnknownException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}