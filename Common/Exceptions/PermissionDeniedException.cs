using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class PermissionDeniedException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.PermissionDenied;

        public PermissionDeniedException() : base(InternalExceptionCode)
        {
        }

        public PermissionDeniedException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
