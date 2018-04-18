public interface IWeapon : IBaseStat, IAdditionalStats
{
    string Name { get; }

    void AddGem(int index, IGem gem);

    void RemoveGem(int index);
}

