using Google.Protobuf.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace discrete_graph_c_
{
    internal class UI
    {
        // Main UI
        public static int selectUI() 
        {
            int mode;
            string tmp;
            do
            {
                Console.Clear();
                Console.WriteLine("\n====================");
                Console.Write("Mode Selection:" +
                         "\n1. Add Person" +
                         "\n2. Add Connection" +
                         "\n3. Add Child" +
                         "\n4. Print Tree" +
                         "\n5. Read File" +
                         "\n6. Create Tree" +
                         "\n\nSelect: ");
                tmp = Console.ReadLine();
                if (tmp.Length < 2 && tmp != "")
                {
                    if (Convert.ToChar(tmp) > 47 && Convert.ToChar(tmp) < 57)
                    { 
                        mode = Convert.ToInt32(tmp);
                        continue;
                    }
                }
                Console.WriteLine("Please Select Again!" +
                    "\nPress any key to try again!");
                Console.ReadKey();
                mode = -1;
            } while (mode < 0 || mode > 6);
            return mode;
        }

        // Add Person UI
        public static Person addPersonUI() {
            Console.WriteLine("\n====================" +
                "\n/To Exit Type Exit in name/");
            Person person = new Person();
            Console.Write("Add member:\n" +
                            "Name: ");
            person.name = Console.ReadLine();
            Console.Write("bDay: ");
            string bDay = "dd/mm/yyyy";
            do
            {
                bDay = Console.ReadLine();
            } while(!Functions.birthdayFormatChecking(bDay));
            person.bDay = DateTime.Parse(bDay, new CultureInfo("en-GB"));
            return person;
        }

        // Select A Person UI
        public static Person selectPersonUI(List<Person> list) 
        {
            Console.WriteLine("\n====================");
            if (list.Count <= 0) return null;
            Console.Write("Select Person: " +
                            "\nname:");
            string name = Console.ReadLine();
            Console.Write("\nbirthday:");
            string bDay = "dd/mm/yyyy";
            do
            {
                bDay = Console.ReadLine();
            } while (!Functions.birthdayFormatChecking(bDay));

            DateTime birthDay = DateTime.Parse(bDay, new CultureInfo("en-GB"));

            foreach (Person person in list)
            {
                if (person.name == name && person.bDay == birthDay) return person;
            }
            Console.WriteLine("No Person Was Found!");
            return null;
        }

        public static bool confirmationUser(string str)
        {
            string txt = "";
            do
            {
                Console.WriteLine("Want to " + str + " (y or n)");
                txt = Console.ReadLine();
                txt.ToLower();
            } while (txt != "y" && txt != "n");
            if (txt == "n") return false;
            return true;
        }
    }
}
