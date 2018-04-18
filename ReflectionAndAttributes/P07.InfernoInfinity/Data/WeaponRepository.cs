using System;
using System.Collections.Generic;
using System.Linq;

public class WeaponRepository : IRepository
{
    private List<IWeapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<IWeapon>();
    }

    public List<IWeapon> Weapons
    {
        get { return this.weapons; }
        private set { this.weapons = value; }
    }

    public void Add(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public IWeapon GetWeapon(string weaponName)
    {
        return this.weapons.FirstOrDefault(w => w.Name == weaponName);
    }
}

