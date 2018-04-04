public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        T[] array = new T[length];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = item;
        }

        return array;
    }
}

