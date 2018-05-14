﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity_Angular5_WebAPI2_ADO.Common.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {

        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.EntityNotFound;

        public EntityNotFoundException() : base(InternalExceptionCode)
        {
        }

        public EntityNotFoundException(string message) : base(InternalExceptionCode, message)
        {
        }


    }
}
