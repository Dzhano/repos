﻿using SoftUniDI_Framework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniDI_Framework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            Dictionary<string, Type> currentImplementation = this.implementations[currentInterface];
            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                    type = currentImplementation.Values.First();
                else throw new ArgumentException($"No available mapping for class: {currentInterface.FullName}");
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;

                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
                this.instances.Add(implementation, instance);
        }

        protected void CreateMapping<TInter, TImpl>()
        {
            if (!this.implementations.ContainsKey(typeof(TInter)))
                this.implementations[typeof(TInter)] = new Dictionary<string, Type>();

            this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
    }
}
