using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
