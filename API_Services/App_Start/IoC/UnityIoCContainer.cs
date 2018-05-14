using Common.Unity;
using System;
using System.Collections.Generic;
using Unity;

namespace Services_WebApi2.App_Start.IoC
{
    public class UnityIoCContainer : IIoCContainer
    {

        private readonly IUnityContainer _unityContainer;

        public UnityIoCContainer(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object Resolve(Type t, string name)
        {
            return _unityContainer.Resolve(t);
        }

        public IEnumerable<object> ResolveAll(Type t)
        {
            return _unityContainer.ResolveAll(t);
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _unityContainer.ResolveAll<T>();
        }
    }
}