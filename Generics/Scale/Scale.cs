﻿using System;

public class Scale<T>
    where T : IComparable<T>

{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {
        var compare = this.left.CompareTo(right);
        if (compare == 1)
        {
            return left;
        }
        else if (compare == -1)
        {
            return right;
        }
        else
        {
            return default(T);
        }
    }
}

