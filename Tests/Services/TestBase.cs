using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Services;

public abstract class TestBase
{
    protected T Parse<T>(string text, int index)
    {
        string value = Split(text)[index];

        return ParseValue<T>(value);
    }

    protected IEnumerable<T> ParseAll<T>(string text)
    {
        string[] ar = Split(text);
        T[] retval = (T[])Array.CreateInstance(typeof(T), ar.Length);
        for (int i = 0; i < ar.Length; i++)
        {
            retval[i] = ParseValue<T>(ar[i]);
        }

        return retval;
    }

    private T ParseValue<T>(string value)
    {
        object retval = null;
        if (typeof(T).Equals(typeof(int)))
        {
            retval = int.Parse(value);
        }
        if (typeof(T).Equals(typeof(long)))
        {
            retval = long.Parse(value);
        }
        if (typeof(T).Equals(typeof(string)) )
        {
            retval = value;
        }

        if (typeof(T).Equals(typeof(char)))
        {
            retval = char.Parse(value);
        }
        return (T)retval;
    }

    protected string[] Split(string text)
    {
        return text.Split(' ').Where(x => x.Length > 0).ToArray();
    }

    protected string[] ReadFromFile(string fileName)
    {
        return System.IO.File.ReadAllLines(@$"{fileName}");
    }
}