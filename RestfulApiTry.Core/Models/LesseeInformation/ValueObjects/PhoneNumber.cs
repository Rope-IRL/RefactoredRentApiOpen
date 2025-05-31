using Microsoft.IdentityModel.Tokens;
using RestFulApiTry.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApiTry.Core.Models.LesseeInformation.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        // Add phone regex here for some country
        private const string phoneRegex = @"";

        public string Number { get; }

        private PhoneNumber(string number)
        {
            this.Number = number;
        }

        public static Result<PhoneNumber> Create(string number)
        {
            // Add phone regex here to check if valid number
            if (number.IsNullOrEmpty())
            {
                return Result<PhoneNumber>.Failure("Phone can't be empty");
            }

            var phoneNumber = new PhoneNumber(number);

            return Result<PhoneNumber>.Success(phoneNumber);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
