using Common.Aop.Attributes;
using System;

namespace IBusinesServices
{
    public interface IExampleService
    {
        [Log]
        string DoWork(string name);
    }
}
