using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Coding_Excercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private int index = 0;

        public Person CreatePerson(string name)
        {
            var person = new Person();
            person.Id = index;
            person.Name = name;

            index++;

            return person;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
