using System;
using System.Collections;

// Интерфейс итератора
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Итератор массива
public class ArrayIterator : IIterator
{
    private object[] _array;
    private int _position = 0; //Текущая позиция для перебора итератора

    public ArrayIterator(object[] array)
    {
        _array = array;
    }

    // Проверка на сл элемент
    public bool HasNext()
    {
        return _position < _array.Length;
    }

    // Следующий элемент
    public object Next()
    {
        return _array[_position++];
    }
}

// Коллеция
public class MyCollection
{
    private object[] _items = { "A", "B", "C", "D" };

    public IIterator GetIterator() // Метод для создания итератора
    {
        return new ArrayIterator(_items); // Возвращаем новый итератор для коллекции
    }
}

class Program
{
    static void Main()
    {
        var collection = new MyCollection();
        var iterator = collection.GetIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}