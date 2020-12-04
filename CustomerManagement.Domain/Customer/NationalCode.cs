using CustomerManagement.Domain.Customer.Exception;
using Framework.Domain;
using System.Collections.Generic;

namespace CustomerManagement.Domain.Customer
{
    public class NationalCode : ValueObject
    {
        public string Code { get; private set; }
        public NationalCode(string code)
        {
            SetNationalCode(code);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Code;
        }

        private void SetNationalCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length < 10)
            {
                throw new CustomerNationalCodeIsNotValidException();
            }
            Code = code;
        }
    }
}
