using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Security
{
    public interface IAuthorizationService
    {
        void Authorize(string claime);

    }
}
