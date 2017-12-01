using Castle.DynamicProxy;
using System;

namespace Common.Aop.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Interface,AllowMultiple =false,Inherited =false)]
    public class BaseAttribute : Attribute
    {
        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void OnExcuting(IInvocation invocation)
        {
        }

        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void OnExited(IInvocation invocation)
        {
        }
    }
}
