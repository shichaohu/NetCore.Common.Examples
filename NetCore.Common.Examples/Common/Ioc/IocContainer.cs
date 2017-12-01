using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Common.Aop;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Ioc
{
    public class IocContainer
    {
        private static ContainerBuilder builder = new ContainerBuilder();

        private static IContainer container;

        private static IocContainer Container;
        
        private IocContainer()
        {
            builder = new ContainerBuilder();
        }
        public static IocContainer GetInstance()
        {
            if (Container == null)
            {
                lock (typeof(IocContainer))
                {
                    if (Container == null)
                    {
                        Container = new IocContainer();
                    }
                }
            }

            return Container;
        }

        /// <summary>
        /// 创建容器
        /// </summary>
        /// <returns></returns>
        public IContainer Build()
        {
            container = builder.Build();

            return container;
        }

        /// <summary>
        /// 注入应用项目和AOP
        /// </summary>
        /// <param name="interfaceAssem">项目接口实现</param>
        /// <param name="implAssem">项目接口</param>
        public void RegisterAssemblyAndAOP(string implAssem, string interfaceAssem)

        {
            try
            {
                var interfaceAssembly = Assembly.Load(interfaceAssem);
                var impAssembly = Assembly.Load(implAssem);
                
                foreach (TypeInfo interfaceType in interfaceAssembly.DefinedTypes)
                {
                    foreach (TypeInfo implType in impAssembly.DefinedTypes)
                    {
                        if (interfaceType.IsAssignableFrom(implType))
                        {
                            builder.RegisterType(implType).InstancePerLifetimeScope().As(interfaceType).EnableInterfaceInterceptors().InterceptedBy(typeof(CustomerInterceptor));
                        }
                    }
                }

                builder.Register(c => new CustomerInterceptor()).Named<IInterceptor>("Intercept").AsSelf().InstancePerLifetimeScope();
            }
            catch (Exception ex)
            {
                throw new Exception("IOC注入失败" + implAssem + ex.Message);
            }
        }

        public T GetService<T>()
        {
            try
            {
                return container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"IOC配置失败:{ typeof(T).Namespace }{ ex.Message}");
            }
        }
    }
}
