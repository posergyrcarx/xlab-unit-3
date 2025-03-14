using System;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    public class MyClass
    {
        public int i;
        public int j;
    }

    public struct MyStruct
    {
        public string name;
        public int age;
    }

    public class MyList<T>
    {
        private T[] array = new T[4];

        public int count { get; }

        public void Push(T i)
        {

        }

        public void Insert(int index, T item)
        {

        }

        public void Remove(int item) { }

        public void IndexOf(T item)
        {
            return;
        }
        public void RemoveAt(T index) { }

        public void Clear() { }
    }

    public void TestFunction<T>(ref T i)
    {
        var objectName = gameObject.name;
        
        Debug.Log($"{objectName} says: {i}");
    }

    void Start()
    {
        var mc = new MyClass();
        
        var ms = new MyStruct();
        var ms2 = new MyStruct();
        
        int i = 10;

        ms = ms2;

        List<MyClass> standartList = new List<MyClass>();

        TestFunction<int>(ref i);

        MyList<MyClass> myList = new MyList<MyClass>();
        myList.Push(new MyClass());
    }
}