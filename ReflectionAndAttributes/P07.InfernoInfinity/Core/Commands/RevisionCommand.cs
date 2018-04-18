using System;

public class RevisionCommand : Command
{
    public RevisionCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string revisionAsString = this.Data[0];

        Type typeOfWeapon = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttr = (MyCustomAttribute)Attribute.GetCustomAttribute(typeOfWeapon, typeof(MyCustomAttribute));

        Console.WriteLine($"{revisionAsString}: {myAttr.Revision}");
    }
}

