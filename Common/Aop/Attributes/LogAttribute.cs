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
            //"日志执行前"
        }

        public override void OnExited(IInvocation invocation)
        {
            //"日志执行后"
        }
    }
}
