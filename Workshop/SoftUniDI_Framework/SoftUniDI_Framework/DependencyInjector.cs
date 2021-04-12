// https://softuni.bg/trainings/resources/officedocument/58177/di-lab-csharp-oop-february-2021/3214
using SoftUniDI_Framework.Modules;

namespace SoftUniDI_Framework
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
