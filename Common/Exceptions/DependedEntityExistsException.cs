namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class DependedEntityExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.EntityAlreadyExists;

        public DependedEntityExistsException() : base(InternalExceptionCode)
        {
        }

        public DependedEntityExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}