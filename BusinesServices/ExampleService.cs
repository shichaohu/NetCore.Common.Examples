using IBusinesServices;
using System;

namespace BusinesServices
{
    public class ExampleService : IExampleService
    {
        public string DoWork(string name) => $"Your input:{name}";
        private int PersongWork() => 1;
    }
}
