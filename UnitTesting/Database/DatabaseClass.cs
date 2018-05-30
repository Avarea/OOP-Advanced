using System;
using System.Linq;

public class DatabaseClass
{
    private const int InitCapacity = 16;

    private int[] integers;
    private int currentIndex = 0;

    public DatabaseClass(int[] integers)
    {
        this.Integers = new int[integers.Length];
        currentIndex = integers.Length - 1;
    }

    public int[] Integers
    {
        get { return integers; }
        set
        {
            if (integers.Length != InitCapacity)
            {
                throw new InvalidOperationException("Initial Array must be exactly 16 integers");
            }
            this.integers = value;
        }
    }

    public void Add(int element)
    {
        if (this.Integers.Length == InitCapacity)
        {
            throw new InvalidOperationException("Maximum length of Array is 16!");
        }
        this.Integers[Integers.Length] = element;
        currentIndex++;
    }

    public void Remove()
    {
        if (this.Integers.Length == 0)
        {
            throw new InvalidOperationException("Array is empty");
        }

        this.Integers[this.Integers.Length - 1] = 0;
        currentIndex--;
    }

    public int[] Fetch()
    {
        int[] subarray = this.integers.Skip(0).Take(this.currentIndex).ToArray();

        return subarray;
    }
}

