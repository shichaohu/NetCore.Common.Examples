using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Aop.Attributes
{
    public sealed class LogAttribute: BaseAttribute
    {
        public override void OnExcuting(IInvocation invocation)
        {
            invocation.ReturnValue = "你写了日志";
        }

        public override void OnExited(IInvocation invocation)
        {

        }
    }
}
