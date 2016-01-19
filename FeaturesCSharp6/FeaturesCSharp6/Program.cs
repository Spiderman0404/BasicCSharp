using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            // Feature1();

            // Feature2();

            // Feature3();

            // Feature4();

            // Feature5();

            // Feature6();

            // Feature7();

            // Feature8();

            Faeture9();
        }

        /// <summary>
        /// Feature 9: Await in catch/finally
        /// </summary>
        private static async void Faeture9()
        {
            System.Console.WriteLine("Feature 9: Await in catch/finally");

            try
            {
                // var pMan = new Person(null);

                var pMan = new Person("         ");
            }
            catch (Exception ex) when (logException(ex))
            {
            }
            catch (ArgumentNullException ex) 
            {
                await LogErrorToFileAsync("Names cannot be null", ex);
            }
            catch (ArgumentException ex2) when (!Debugger.IsAttached)
            {
                await LogErrorToFileAsync("Names cannot be blank", ex2);
            }
            finally
            {
                System.Console.ReadKey();
                System.Console.WriteLine("");
            }
        }

        public static async Task LogErrorToFileAsync(string msg, Exception e)
        {
            using (var file = File.AppendText("errors.log"))
            {
                await file.WriteAsync($"{msg}: Exception: {e}");
            }
        }

        /// <summary>
        /// Feature 8: Exception filters
        /// </summary>
        private static void Feature8()
        {
            System.Console.WriteLine("Feature 8: Exception filters");

            try
            {
                // var pMan = new Person(null);

                var pMan = new Person("         ");
            }
            catch (Exception ex) when (logException(ex))
            {
            }
            catch (Exception) when (!Debugger.IsAttached)
            {
                System.Console.WriteLine("Debugger is not attached!");
            }
            finally
            {
                System.Console.ReadKey();
                System.Console.WriteLine("");
            }
        }

        public static bool logException(Exception e)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            System.Console.WriteLine("Error: {0}", e);
            Console.ForegroundColor = oldColor;

            return false;
        }


        /// <summary>
        /// Feature 7: index initializers
        /// </summary>
        private static void Feature7()
        {
            System.Console.WriteLine("Feature 7: index initializers");

            // object initializer
            var names = new List<string>
            {
                "Franz",
                "Richard",
                "Luisa"
            };

            // index initializer
            var dict = new Dictionary<int, string>
            {
                [4] = "Franz",
                [9] = "Richard",
                [11] = "Luisa"
            };

            dict.Add(1, "Phillip");
            dict[3] = "Lena";

            System.Console.ReadKey();
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Feature 6: null conditional operator
        /// </summary>
        private static void Feature6()
        {
            System.Console.WriteLine("Feature 6: null conditional operator");

            var pMan = new Person(new DateTime(1969, 4, 4))
            {
                FirstName = "Michael",
                FamilyName = "Hürtgen"
            };

            pMan.Married(null);

            pMan.MarriedOldStyle(null);

            System.Console.WriteLine($"Full name: {pMan?.FullName}");

            System.Console.ReadKey();
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Feature 5: name of
        /// </summary>
        private static void Feature5()
        {
            System.Console.WriteLine("Feature 5: name of");

            var pMan = new Person(new DateTime(1969, 4, 4))
            {
                FirstName = "Michael",
                FamilyName = "        "
            };

            if(string.IsNullOrWhiteSpace(pMan.FamilyName))
            {
                System.Console.WriteLine($"Property {nameof(pMan.FamilyName)} is null or white space.");
            }
            
            System.Console.ReadKey();
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Feature 4: String Interpolation
        /// </summary>
        private static void Feature4()
        {
            System.Console.WriteLine("Feature 4: String Interpolation");

            var pMan = new Person(new DateTime(1969, 4, 4))
            {
                FirstName = "Michael",
                FamilyName = "Hürtgen",
                IsMale = true
            };

            // so far....
            System.Console.WriteLine("Name : " + pMan.FullName + " Birthday: " + pMan.Birthday.ToShortDateString());

            System.Console.WriteLine("");

            // with string interpolation...
            System.Console.WriteLine(
                $"Name : {pMan.FullName} Birthday: {pMan.Birthday.ToShortDateString()} Male: {(pMan.IsMale ? "Yes" : "No")}");

            System.Console.ReadKey();
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Feature 3: "using static"
        /// </summary>
        private static void Feature3()
        {
            System.Console.WriteLine("Feature 3: using static");

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
            System.Console.WriteLine("Feature 2: Expression bodied function members");

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
            System.Console.WriteLine("Feature 1: Read only property");

            var p = new Person(new DateTime(1969, 4, 4));

            System.Console.WriteLine(p.Birthday);

            System.Console.ReadKey();
            System.Console.WriteLine("");
        }
    }

    class Person
    {
        public bool IsMale { get; set; }

        #region Feature 2

        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public string FullName => FirstName + " " + FamilyName;

        public char this[int index] => FamilyName[index];

        public void Married(Person person) => FamilyName = person?.FamilyName;

        // old style
        public void MarriedOldStyle(Person person)
        {
            if( person != null)
            {
                FamilyName = person.FamilyName;
            }
        }

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

        public Person(String name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name), "The person must have a name.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name), "The person must have a non-blank name.");

            FamilyName = name;
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
