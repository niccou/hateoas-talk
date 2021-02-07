using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Shared
{
    public record OperationResult
    {
        protected OperationResult() { }

        public bool Success { get; init; }

        public static OperationResult Succeed() => new OperationResult
        {
            Success = true
        };

        public static OperationResult Failed() => new OperationResult
        {
            Success = false
        };
    }

    public record OperationResult<TResult> : OperationResult
    {
        private OperationResult(OperationResult original) : base(original)
        {
        }

        public TResult? Result { get; init; }

        public static new OperationResult<TResult> Failed() => new OperationResult<TResult>(OperationResult.Failed());

        public static OperationResult<TResult> Succeed(TResult result) => new OperationResult<TResult>(Succeed())
        {
            Result = result
        };
    }
}
