﻿using System;

namespace Nimbus.Infrastructure
{
    internal interface IRequestResponseCorrelationWrapper
    {
        Type ResponseType { get; }
        void SetResponse(object response);
        void Throw(string exceptionMessage, string exceptionStackTrace);
    }
}