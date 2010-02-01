using System;

namespace MakeItEasy.Tests
{
    public class ThingToMake
    {
        public readonly int age;
        public readonly string name;

        public ThingToMake(String name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}