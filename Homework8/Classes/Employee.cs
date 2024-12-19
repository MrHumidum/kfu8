using System;

namespace Homework8
{
    public abstract class Employee
    {
        public string name;

        protected Employee(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }

}
