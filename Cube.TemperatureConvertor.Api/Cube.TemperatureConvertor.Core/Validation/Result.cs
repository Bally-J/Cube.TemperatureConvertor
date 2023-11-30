using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube.Core.Validation
{
    public class Result
    {
        public bool IsSuccess { get; }
        public Error Error { get; }

        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
                throw new InvalidOperationException();

            if(!isSuccess && error == Error.None)    
                throw new InvalidOperationException();
            
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result<T> Success<T>(T value) => new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);
        public static Result<T> Failure<T>(T value, Error error) => new(value, false, error);

        public static object Failure<T>(Error error) => new Result(false, error);
    }
    
    public class Result<TValue> : Result
    {
        private readonly TValue? value;

        public Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            this.value = value;
        }

        public TValue Value => IsSuccess ? value! : throw new InvalidOperationException();

        public static implicit operator Result<TValue>(TValue? value) => value;
    }
}
