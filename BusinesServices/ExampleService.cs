using Common.Aop.Attributes;
using IBusinesServices;
using System;

namespace BusinesServices
{
    [Log]
    public class ExampleService : IExampleService
    {
        [Log]
        public string DoWork(string name) => $"Your input:{name}，length：{PersongWork(name)}";
        private int PersongWork(string name) => name.Length;
    }
}
