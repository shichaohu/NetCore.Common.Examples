using Castle.DynamicProxy;
using Common.Aop.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Common.Aop
{
    internal class CustomerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attributes1 = invocation.GetConcreteMethodInvocationTarget().GetCustomAttributes(typeof(BaseAttribute), true);
            var attributes2 = invocation.GetConcreteMethodInvocationTarget().DeclaringType.GetCustomAttributes(typeof(BaseAttribute), true);
            var attributes3 = invocation.GetConcreteMethod().GetCustomAttributes(typeof(BaseAttribute), true);
            var attributes4 = invocation.GetConcreteMethod().DeclaringType.GetCustomAttributes(typeof(BaseAttribute), true);

            var attributes = new object[attributes1.Length + attributes2.Length + attributes3.Length + attributes4.Length];
            attributes1.CopyTo(attributes, 0);
            attributes2.CopyTo(attributes, attributes1.Length);
            attributes3.CopyTo(attributes, attributes1.Length + attributes2.Length);
            attributes4.CopyTo(attributes, attributes1.Length + attributes2.Length + attributes3.Length);

            var attrList = new ArrayList();
            foreach (var attr in attributes)
            {
                if (!attrList.Contains(attr))
                    attrList.Add(attr);
            }

            if (attributes.Length == 0)
            {
                invocation.Proceed();
                return;
            }

            ExecIntercept(invocation, attrList);
        }

        public void ExecIntercept(IInvocation invocation, ArrayList attributes, int i = 0)
        {
            var attribute = (BaseAttribute)attributes[i];
            attribute.OnExcuting(invocation);

            if (invocation.ReturnValue != null) return;
            if (++i < attributes.Count)
                ExecIntercept(invocation, attributes, i);

            if (invocation.ReturnValue == null && i >= attributes.Count)
                invocation.Proceed();


            attribute.OnExited(invocation);
        }
    }
}
