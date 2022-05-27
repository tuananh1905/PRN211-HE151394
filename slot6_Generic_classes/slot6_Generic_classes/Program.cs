﻿using System;

namespace slot6_Generic_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<string> name = new MyClass<string>() { Value = "Jack" };
            Console.WriteLine(name);
            MyClass<float> version = new MyClass<float>() { Value = 5.5f };
            Console.WriteLine(version);
            dynamic obj = new { Id = 1, Name = "David" };
            MyClass<dynamic> myClass = new MyClass<dynamic> { Value = obj };
            Console.WriteLine(myClass);
            Console.ReadLine();
        }
    }
    public class MyClass<T>
    {
        private T data;
        public T Value
        {
            get => data;
            set => data = value;
        }
        public override string ToString() => $"Value:{data}";
    }
}
