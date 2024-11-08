﻿using Google.Protobuf.Compiler;
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
            Console.WriteLine("\n====================");
            Console.Write("Mode Selection:" +
                     "\n1. Add Person" +
                     "\n2. Add Connection" +
                     "\n3. Add Child" +
                     "\n4. Print Tree"+
                     "\n\nSelect: ");
            int mode = Convert.ToInt32(Console.ReadLine());
            return mode;
        }

        // Add Person UI
        public static Person addPersonUI() {
            Console.WriteLine("\n====================");
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

            string format = "dd/mm/yyyy";
            DateTime birthDay = DateTime.Parse(bDay, new CultureInfo("en-GB"));

            foreach (Person person in list)
            {
                if (person.name == name && person.bDay == birthDay) return person;
            }
            Console.WriteLine("No Person Was Found!");
            return null;
        }
    }
}
