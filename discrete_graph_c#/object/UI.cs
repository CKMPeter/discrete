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
                Console.WriteLine("\n====================================");
                Console.Write("Mode Selection:" +
                         "\n1. Add Person" +
                         "\n2. Update Person" +
                         "\n3. Print Tree" +
                         "\n4. Print File" +
                         "\n5. Read File" +
                         "\n6. Create Tree" +
                         "\n7. Check Relationship" +
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
            } while (mode < 0 || mode > 7);
            return mode;
        }

        private static List<Person> person = new List<Person>();

        // Add Person UI
        public static Person addPersonUI() {
            Console.WriteLine("\n====================================" +
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
        public static Person removePersonUI()
        {
            Console.WriteLine("\n====================" +
                "\n/To Exit Type Exit in name/");
            Console.Write("Remove member:\n" +
                          "Name: ");
            string nameToRemove = Console.ReadLine();
            if (nameToRemove.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                return null;

            Person personToRemove = person.FirstOrDefault(p => p.name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));
            if (personToRemove != null)
            {
                person.Remove(personToRemove);
                return personToRemove; // Return the removed person
            }
            else
            {
                Console.WriteLine("Person not found.");
                return null; // Return null if no person was found
            }
        }
        // Select A Person UI
        public static Person selectPersonUI(List<Person> list) 
        {
            Console.WriteLine("\n====================================");
            if (list.Count <= 0) return null;
            Console.Write("Select Person: " +
                            "\nPersonID:");
            string pID = Console.ReadLine();
            foreach (Person person in list)
            {
                if (person.PersonID == pID) return person;
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
       
        public static string partSelection()
        {
            string tmp = "";
            do
            {
                tmp = Console.ReadLine();
                tmp = tmp.ToLower().Trim();
                if (tmp == "dob") break;
                if (tmp == "name") break;
            } while (true);
            return tmp;
        }
    }
}
