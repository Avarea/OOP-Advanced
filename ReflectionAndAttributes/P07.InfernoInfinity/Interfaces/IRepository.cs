public interface IRepository
{
    void Add(IWeapon data);

    IWeapon GetWeapon(string weaponName);
}

