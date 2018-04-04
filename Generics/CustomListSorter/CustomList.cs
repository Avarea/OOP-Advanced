﻿using System;
using System.Collections.Generic;
using System.Linq;


public class CustomList<T> where T : IComparable<T>
{
    private readonly List<T> items;

    public IReadOnlyCollection<T> Items => this.items.AsReadOnly();

    public CustomList()
    {
        this.items = new List<T>();
    }

    public T this[int index]
    {
        get
        {
            return this.items[index];
        }
        set
        {
            this.items[index] = value;
        }
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove(int index)
    {
        var element = items[index];
        this.items.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        if (items.Contains(element))
        {
            return true;
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }

    public int Count => this.items.Count;

    public int CountGreaterThan(T element)
    {
        var counter = 0;
        foreach (var item in items)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public void Sort()
    {
        this.items.Sort();
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }
}

