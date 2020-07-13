using Inveon.Comon.InveonEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Model.ResultModel
{
    public class SuccessResult : Result
    {
        public SuccessResult(object Root, string Message) : base(true, Root, Message, ResultCodeEnum.Success)
        {
        }
    }
}
