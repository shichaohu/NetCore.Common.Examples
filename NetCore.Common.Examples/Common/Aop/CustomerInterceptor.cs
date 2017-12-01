using Castle.DynamicProxy;
using Common.Aop.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Aop
{
    internal class CustomerInterceptor : IInterceptor
    {
        /// <summary>
        /// 拦截方法
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            var attrs = invocation.GetConcreteMethodInvocationTarget().GetCustomAttributes(typeof(BaseAttribute), true);
            if (attrs.Length == 0)
            {
                invocation.Proceed();
                return;
            }

            for(int i=0;i<attrs.Length;i++)
            {
                ((BaseAttribute)attrs[i]).OnExcuting(invocation);
            }
            invocation.Proceed();
            for (int i = attrs.Length-1; i >=0; i--)
            {
                ((BaseAttribute)attrs[i]).OnExited(invocation);
            }
        }

        public void AttributeRecursionIntercept(IInvocation invocation, object[] attrs, int i = 0)
        {
            
        }
    }
}
