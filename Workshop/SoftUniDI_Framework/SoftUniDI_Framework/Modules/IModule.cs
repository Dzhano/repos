using System;

namespace SoftUniDI_Framework.Modules
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type currentInterface, object attribute);

        object GetInstance(Type type);

        void SetInstance(Type implementation, object instance);
    }
}
