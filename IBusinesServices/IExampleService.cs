using Common.Aop.Attributes;
using System;

namespace IBusinesServices
{
    [Log]
    public interface IExampleService
    {
        [Log]
        string DoWork(string name);
    }
}
