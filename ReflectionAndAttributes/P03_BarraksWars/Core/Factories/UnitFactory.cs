using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(e => e.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is Not a valid Unit type");
            }

            IUnit unit = (IUnit) Activator.CreateInstance(model);
            return unit;
        }
    }
}
