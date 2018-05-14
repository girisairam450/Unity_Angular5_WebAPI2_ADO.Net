namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class EntityDetailsNotFoundException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.EntityDetailsNotFound;

        public EntityDetailsNotFoundException() : base(InternalExceptionCode)
        {
        }

        public EntityDetailsNotFoundException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}