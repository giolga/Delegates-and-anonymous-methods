using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesPractice
{
    internal class Program
    {
        public delegate bool FilterDelegate(Person p);
        static void Main(string[] args)
        {
            Person p1 = new Person() { Name = "El Kumi", Age = 21 };
            Person p2 = new Person() { Name = "Charles", Age = 68 };
            Person p3 = new Person() { Name = "Mufasa", Age = 12 };
            Person p4 = new Person() { Name = "CHAMA", Age = 25 };


            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            DisplayPeople("Kids", people, IsMinor);
            DisplayPeople("Adults", people, IsAdult);
            DisplayPeople("Seniors", people, IsSenior);



            // Here we created a new variable called filter of type FilterDelegate
            // then we assigned an anonymous method to it instead of an already defined method
            FilterDelegate filter = delegate (Person p)
            {
                return p.Age >= 20 && p.Age <= 30;
            };

            DisplayPeople("Between 20 and 30", people, filter);

            DisplayPeople("All", people, delegate (Person p) { return true; }); //anonymous

            Console.ReadKey();
        }

        static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
        {
            Console.WriteLine(title);
            foreach (Person person in people)
            {
                if (filter(person))
                {
                    Console.WriteLine("\t" + person.Name);
                }
            }
        }
        static bool IsMinor(Person person)
        {
            return person.Age < 18;
        }

        static bool IsAdult(Person person)
        {
            return person.Age >= 18;
        }

        static bool IsSenior(Person person)
        {
            return person.Age >= 65;
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
