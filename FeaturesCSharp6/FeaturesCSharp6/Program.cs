using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace FeaturesCSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Feature1();
        }

        /// <summary>
        /// Feature 1: Read only property
        /// </summary>
        private static void Feature1()
        {
            var p = new Person(new DateTime(1969, 4, 4));

            WriteLine(p.Birthday);

            ReadKey();
        }
    }

    class Person
    {
        /// <summary>
        /// Feature 1: Read only property
        /// </summary>
        public DateTime Birthday { get; }

        public Person(DateTime birthday)
        {
            Birthday = birthday;
        }

        /// <summary>
        /// Feature 1: Read only property
        /// </summary>
        /// <param name="newBirthday"></param>
        public void ChangeBirthday(DateTime newBirthday)
        {
            // Birthday = newBirthday;
        }

    }

}
