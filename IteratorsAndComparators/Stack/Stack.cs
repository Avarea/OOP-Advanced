using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Stack<T> : IEnumerable<T>
{
    private List<T> collection;

    public Stack()
    {
        this.collection = new List<T>();
    }

    public void Push(T element)
    {
        this.collection.Add(element);
    }

    public T Pop()
    {
        if (!this.collection.Any())
        {
            throw new ArgumentException("No elements");
        }

        T lastElement = this.collection[this.collection.Count - 1];
        this.collection.RemoveAt(this.collection.Count - 1);

        return lastElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.collection.Count - 1; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
