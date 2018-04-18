using System;

public class AuthorCommand : Command
{
    public AuthorCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string author = this.Data[0];

        Type weaponType = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttr =
            (MyCustomAttribute) Attribute.GetCustomAttribute(weaponType, typeof(MyCustomAttribute));

        Console.WriteLine($"{author}: {myAttr.Author}");
    }
}

