using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inveon.Comon.InveonEnums;

namespace Inveon.Model.ResultModel
{
    public class FailureResult : Result
    {

        public FailureResult() : base(false, null, "An error has been Occured.", ResultCodeEnum.Failure)
        {
            // loglama vs işlemleri burada yapılabilir.
        }

        public FailureResult(string message) : base(false, null, message, ResultCodeEnum.Failure)
        {
            // loglama vs işlemleri burada yapılabilir.
        }

        public FailureResult(ResultCodeEnum resultCodeEnum) : base(false, null, "An error has been Occured.", resultCodeEnum)
        {
            // loglama vs işlemleri burada yapılabilir.
        }
    }
}
