using System.Collections.Generic;

public class Box<T>
{
    private Stack<T> box;

    public Box()
    {
        this.box = new Stack<T>();
    }

    public int Count => this.box.Count;

    public void Add(T element)
    {
        box.Push(element);
    }

    public T Remove()
    {
        var element = box.Pop();
        return element;
    }
}

