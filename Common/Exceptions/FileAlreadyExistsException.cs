namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class FileAlreadyExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.FileAlreadyExist;

        public FileAlreadyExistsException() : base(InternalExceptionCode)
        {
        }

        public FileAlreadyExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}