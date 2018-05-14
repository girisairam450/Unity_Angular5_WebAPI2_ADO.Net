namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class EntityAlreadyExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.EntityAlreadyExists;

        public EntityAlreadyExistsException() : base(InternalExceptionCode)
        {
        }

        public EntityAlreadyExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}