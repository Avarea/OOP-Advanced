using System;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T>
{
    public ListyIterator(ICollection<T> collection)
    {
        this.Index = 0;
        this.Collection = new List<T>(collection);
    }

    public IReadOnlyList<T> Collection { get; private set; }

    private int Index { get; set; }

    public bool Move()
    {
        if (this.Index + 1 < this.Collection.Count)
        {
            this.Index++;
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (!this.Collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.Collection[this.Index]);
    }

    public bool HasNext()
    {
        if (this.Index == this.Collection.Count - 1)
        {
            return false;
        }

        return true;
    }
}
