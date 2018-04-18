using System;

public class DescriptionCommand : Command
{
    public DescriptionCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        Type type = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttr = (MyCustomAttribute)Attribute.GetCustomAttribute(type, typeof(MyCustomAttribute));

        Console.WriteLine($"Class description: {myAttr.Description}");
    }
}