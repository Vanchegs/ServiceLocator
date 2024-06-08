using System;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase.ServiceLocator
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> Services;

        public static void Register<TService>(TService service) where TService : IService
        {
            if (Services.ContainsKey(typeof(TService)))
            {
                Debug.Log("This service has already been registered ");
                return;
            }
            
            Services.Add(typeof(TService), service);
        }

        public static void Deregister<TService>() where TService : IService
        {
            if (!Services.ContainsKey(typeof(TService)))
            {
                Debug.Log("This service is not registered");
                return;
            }
            
            Services.Remove(typeof(TService));
        }

        public static IService GetService<TService>() where TService : IService
        {
            if (!Services.ContainsKey(typeof(TService)))
            {
                Debug.Log("This service is not registered");
                return null;
            }

            return (TService)Services[typeof(TService)];
        }
    }
}
