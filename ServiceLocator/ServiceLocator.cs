using System;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase.ServiceLocator
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> services;

        public static void Register<TService>(TService service) where TService : IService
        {
            if (services.ContainsKey(typeof(TService)))
            {
                Debug.Log("This service has already been registered ");
                return;
            }
            
            services.Add(typeof(TService), service);
        }

        public static void Deregister<TService>() where TService : IService
        {
            if (!services.ContainsKey(typeof(TService)))
            {
                Debug.Log("This service is not registered");
                return;
            }
            
            services.Remove(typeof(TService));
        }

        public static IService GetService<TService>() where TService : IService
        {
            if (!services.ContainsKey(typeof(TService)))
            {
                Debug.Log("This service is not registered");
                return null;
            }

            return (TService)services[typeof(TService)];
        }
    }
}
