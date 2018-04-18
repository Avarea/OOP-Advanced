using System;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(Rarity rarity, string type, string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var model = assembly.GetType(type + "Weapon");

        if (model == null)
        {
            throw new ArgumentException("Invalid weapon!");
        }

        bool isAssignable = typeof(IWeapon).IsAssignableFrom(model);

        if (!isAssignable)
        {
            throw new ArgumentException($"{type} is not a weapon!");
        }

        return (IWeapon) Activator.CreateInstance(model, new object[] {name, rarity});
    }
}

