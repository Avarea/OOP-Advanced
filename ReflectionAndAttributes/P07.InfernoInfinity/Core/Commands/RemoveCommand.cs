﻿using System;

public class RemoveCommand : Command
{
    [Inject]
    private IRepository repository;

    public RemoveCommand(string[] data, IRepository repository) : base(data)
    {
        this.repository = repository;
    }

    public override void Execute()
    {
        int index = int.Parse(Data[2]);

        var weaponName = Data[1];
        var weapon = this.repository.GetWeapon(weaponName);

        if (weapon == null)
        {
            throw new ArgumentException("Invalid Weapon!");
        }

        try
        {
            weapon.RemoveGem(index);
        }
        catch (Exception)
        {

        }
    }
}
