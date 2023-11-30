using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube.Core.Validation
{
    public class Error : IEquatable<Error>
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static readonly Error None = new(string.Empty, String.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "The specified value is null");

        public static implicit operator string(Error error) { return error.Code; }

        public static bool operator ==(Error? a, Error? b)
        {
            if(a is null && b is null)
                return true; 

            if(a is null || b is null)
                return false;

            if(a.Code == b.Code)
                return true;

            return false;
        }

        public static bool operator !=(Error? a, Error? b)
        {
            
            if(a is null && b is null)
                return false; 

            if(a is null || b is null)
                return true;

            if(a.Code == b.Code)
                return false;

            return true;
        }

        public bool Equals(Error? other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if(obj is null || obj is not Error)
                return false;

            return Equals(obj! as Error);
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }
    }
}
