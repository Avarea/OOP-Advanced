using System;

public class ReviewersCommand : Command
{
    public ReviewersCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string reviewersString = this.Data[0];

        Type type = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttr = (MyCustomAttribute) Attribute.GetCustomAttribute(type, typeof(MyCustomAttribute));

        Console.WriteLine($"{reviewersString}: {string.Join(", ", myAttr.Reviewers)}");

    }
}

