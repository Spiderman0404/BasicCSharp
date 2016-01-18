using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Feature 3: using static
using static System.Math;

namespace FeaturesCSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Feature 1");
            Feature1();

            System.Console.WriteLine("Feature 2");
            Feature2();

            System.Console.WriteLine("Feature 3");
            Feature3();
        }

        private static void Feature3()
        {
            double number = 25.0;

            double sqrt = Sqrt(number);
            sqrt = Round(sqrt);

            System.Console.WriteLine("sqrt 25: " + sqrt.ToString());
            System.Console.ReadKey();

            System.Console.WriteLine("");
        }

        /* 
        // Don't work with Sqrt from System.Math
        double Sqrt(double number)
        {
            return number;
        }
        */


        /// <summary>
        /// Feature 2: Expression bodied function members
        /// </summary>
        private static void Feature2()
        {
            var pMan = new Person(new DateTime(1969, 4, 4))
            {
                FirstName = "Michael",
                FamilyName = "Hürtgen"
            };

            System.Console.WriteLine("Full name: " + pMan.FullName);
            System.Console.WriteLine("Character at Index 2: " + pMan.FullName[2]);

            System.Console.ReadKey();

            var pWoman = new Person(new DateTime(1974, 5, 10))
            {
                FirstName = "Diana",
                FamilyName = "Sacchi"
            };

            System.Console.WriteLine("Full name of bride: " + pWoman.FullName);
            pWoman.Married(pMan);
            System.Console.WriteLine("After marriage : " + pWoman.FullName);

            System.Console.ReadKey();
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Feature 1: Read only property
        /// </summary>
        private static void Feature1()
        {
            var p = new Person(new DateTime(1969, 4, 4));

            System.Console.WriteLine(p.Birthday);

            System.Console.ReadKey();
            System.Console.WriteLine("");
        }
    }

    class Person
    {
        #region Feature 2

        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public string FullName => FirstName + " " + FamilyName;

        public char this[int index] => FamilyName[index];

        public void Married(Person person) => FamilyName = person.FamilyName;

        #endregion

        #region Feature 1

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

        #endregion

    }

}
