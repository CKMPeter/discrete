using Microsoft.VisualBasic;
using Org.BouncyCastle.Math.Field;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace discrete_graph_c_
{
    public class Functions
    {
        public static List<string> readFile(string str)//Code for file txt reading
        {
            String line;
            string A = "";
            List<string> lines = new List<string>();
            int count = 0;
            try
            {
                // Pass the file path and file name to the StreamReader constructor
                using (StreamReader sr = new StreamReader(str))
                {
                    // Continue to read until you reach the end of the file
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (char c in line)
                        {
                            if (c == '-')
                            {
                                count++;
                            }
                            if (c == ',')
                            {
                                // Append A to lines and reset A
                                A = A + c +count;
                            }
                            else if (char.IsLetterOrDigit(c) || c == '(' || c == ')' || c == '/') // Check for alphanumeric or parentheses
                            {
                                A += c;
                            }
                        }
                        lines.Add(count+A);
                        A = "";
                        count = 0;
                        //write the line to console window
                        Console.WriteLine(line);
                    } while (line != null) ;
                    //close the file
                    sr.Close();
                    Console.WriteLine("press any key to continue...\n");
                    Console.ReadLine();
                    return lines;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public static void printToFile(List<Person> randomPerson, string pth)
        {
            List<Person> checkedList = new List<Person>();
            try
            {
                using (StreamWriter wt = new StreamWriter (pth))
                {
                    foreach(Person person in randomPerson)
                    {
                        // Skip if the person's partner has already been checked
                        if (person.partner != null && checkedList.Contains(person.partner))
                            continue;
                        checkedList.Add(person);
                        int gender, gender_;
                        gender = gender_ = 0 ;
                        if (person.gender) gender = 1;
                        if (person.partner.gender) gender_ = 1;
                        if (person.bDay != default(DateTime)) wt.Write(new string('-', person.step) + person.name + "("+ person.bDay.Date.ToString("dd/MM/yyyy")+ ")"+gender+",");
                        else wt.Write(new string('-', person.step) + person.name + "()"+gender+",");
                        if (person.partner!= null)
                        {
                            if(person.partner.bDay != default(DateTime)) wt.WriteLine(person.partner.name + "(" + person.partner.bDay.Date.ToString("dd/MM/yyyy") + ")"+gender_);
                            else wt.WriteLine(person.partner.name + "()"+gender_);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return;
            }
            finally
            {
                Console.WriteLine("Print Complete!!!.");
                Console.ReadKey();
            }
        }
        public static bool birthdayFormatChecking(string bDay) {
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Check if the input matches the pattern
            if (regex.IsMatch(bDay))
            {
                return true;
            }
            else return false;
        }

        public static void dfsTraverse(Person person)
        {
            if (person == null)
            {
                Console.Write($")");
                return;
            }
            // Display current person's details
            Console.Write($"( {person.name},");

            // Display partner's details if they exist
            if (person.partner != null)
            {
                Console.Write($" {person.partner.name})");
            }else Console.Write(")");

            // Traverse children
            foreach (var child in person.child)
            {
                Console.Write("->");
                dfsTraverse(child); // Recursive call for each child
            }
        }

        public static void bfsTraverse(Person person)
        {
            if (person == null)
            {
                Console.WriteLine(")");
                return;
            }

            Queue<Person> queue = new Queue<Person>();
            HashSet<Person> visited = new HashSet<Person>(); // Track visited persons and partners

            queue.Enqueue(person);
            visited.Add(person);

            Console.WriteLine("("); // Start traversal

            while (queue.Count > 0)
            {
                Person current = queue.Dequeue();

                // Display current person's details
                Console.Write($"( {current.name}");

                // Display partner's details if they exist and haven't been visited
                if (current.partner != null && !visited.Contains(current.partner))
                {
                    Console.Write($", {current.partner.name}");
                    visited.Add(current.partner); // Mark partner as visited
                }
                Console.Write(")->");

                // Enqueue each child to process in the next level
                foreach (var child in current.child)
                {
                    if (!visited.Contains(child)) // Process only if not visited
                    {
                        queue.Enqueue(child);
                        visited.Add(child); // Mark child as visited
                    }
                }
            }
            Console.WriteLine(")"); // End traversal
        }



        public static List<Person> fromStringCreateInfo(List<String> lines)
        {
            Person tmp = new Person();
            Person tmp_ = new Person();
            List <Person> list = new List<Person>();
            int step;
            string name, dob;
            bool gender;
            int flag = 0;
            foreach(string line in lines)
            {
                name = "";
                dob = "";
                flag = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ',')
                    {
                        for (int j = 1; j < i; j++)
                        {
                            if (line[j] == ')') break;
                            if (flag != 0) dob += line[j];
                            if (line[j] != '(')
                            {
                                if(flag == 0)name += line[j];
                            }
                            else flag = j;
                        }
                        if (line[i - 1] - '0' == 1) gender = true; else gender = false;
                        if (dob != "")
                        {
                            DateTime birthDay = DateTime.Parse(dob, new CultureInfo("en-GB"));
                            tmp = new Person(name, birthDay, line[0] - '0', gender);
                        }
                        else tmp = new Person(name, line[0] - '0', gender);
                        //reset for next person
                        if (line[i + 1] == null) break;
                        name = "";
                        dob = "";
                        flag = 0;
                        gender = false;
                        for (int m = line.Length - 3; m > i + 1; m--)
                        {
                            if (flag != 0) name = line[m] + name;
                            if (line[m] != '(')
                            {
                                if(flag == 0) dob = line[m] + dob;
                            }
                            else flag = m;
                        }
                        if (line[line.Length - 1] - '0' == 1) gender = true;
                        if (dob != "")
                        {
                            DateTime birthDay = DateTime.Parse(dob, new CultureInfo("en-GB"));
                            tmp_ = new Person(name, birthDay, line[i + 1] - '0', gender);
                        }
                        else tmp_ = new Person(name, line[i + 1] - '0', gender);
                        tmp_.partner = tmp;
                        tmp.partner = tmp_;
                        list.Add(tmp);
                        list.Add(tmp_);

                        //add Partner for each line
                        
                        
                        break;
                    }
                }
            }
            return list;
        }
        public static List<Person> CreateTreeFromList(List<Person> list)
        {
            List<Person> checkedList = new List<Person>();
            Person tmp = new Person();
            foreach (var person in list)
            {
                // Skip if the person's partner has already been checked
                if (person.partner != null && checkedList.Contains(person.partner))
                    continue;

                checkedList.Add(person);

                // Loop through checkedList to find and set parents
                foreach (var checkedPerson in checkedList)
                {
                    if (checkedPerson.step == person.step - 1)
                    {
                        AddParent(person, checkedPerson);
                        RemoveParent(person, checkedPerson);
                        tmp = checkedPerson;
                        //Person[] parent_ = new Person[2];
                        //parent_[0] = checkedPerson;
                        //parent_[1] = checkedPerson.partner;
                        //person.parent = parent_;
                        //person.partner.parent = parent_;
                    }
                }
                tmp.addChild(person);
                tmp.addChild(person.partner);
            }
            return list;
        }

        public static void AddParent(Person A, Person B)
        {
            if (A == null || B == null) return;

            // Initialize A's parent array if it is null
            if (A.parent == null) A.parent = new Person[2];

            // Add B as the first parent if not already set
            if (A.parent[0] == null)
            {
                A.parent[0] = B;
                A.parent[1] = B.partner;
            }
            else if (A.parent[1] == null && A.parent[0] != B) A.parent[1] = B;

            // Handle A's partner's parents
            if (A.partner != null && !string.IsNullOrEmpty(A.partner.name))
            {
                if (A.partner.parent == null) A.partner.parent = new Person[2];

                // Add B and B's partner as A's partner's parents
                if (A.partner.parent[0] == null)
                {
                    A.partner.parent[0] = B;
                    A.partner.parent[1] = B.partner;
                }
                else if (A.partner.parent[1] == null && A.partner.parent[0] != B) A.partner.parent[1] = B.partner;
            }
        }
        public static void RemoveParent(Person A, Person B)
        {
            if (A == null || B == null) return;

            // Remove B from A's parent array
            if (A.parent != null)
            {
                // Clear the reference to the first parent
                if (A.parent[0] == B)   A.parent[0] = null; 
                // Clear the reference to the second parent
                else if (A.parent[1] == B)  A.parent[1] = null; 
            }

            // Handle A's partner's parents
            if (A.partner != null && !string.IsNullOrEmpty(A.partner.name) && A.partner.parent != null)
            {
                // Clear the reference to the first parent of the partner
                if (A.partner.parent[0] == B)   A.partner.parent[0] = null; 
                // Clear the reference to the second parent of the partner
                else if (A.partner.parent[1] == B.partner)   A.partner.parent[1] = null; 
            }
        }

        public static void printList(List<Person> randomPerson)
        {
            if (randomPerson.Count == 0) return;
            Console.WriteLine("====================================================");
            foreach (var person in randomPerson) { 
                Console.WriteLine("Name: " + person.name + "| | ID: " + person.PersonID);
            }
        }

        public static void relationCheck(Person A, Person B)
        {
            if (A == null || B == null) return;
            string relation = "";
            string tmp;
            int distance = Math.Abs(A.step - B.step);
            if (distance == 0) 
            {
                Console.WriteLine(A.name + "and " + B.name + " are Partner.");
                return;
            }
            if (A.step - B.step > 0 )
            {
                Console.Write(B.name + " is " + A.name + "'s ");
                if (distance < 2)
                {
                    if (B.gender) Console.Write("Father");
                    else Console.Write("Mother");
                    Console.Write(A.name + " is " + B.name + "'s Child");
                }
                else
                {
                    tmp = "";
                    for (int i = 1; i < distance; i++)
                    {
                        tmp += "Great ";
                    }
                    if (B.gender) Console.Write(tmp + "Grand Father");
                    else Console.Write(tmp + "Grand Mother");
                    Console.Write(A.name + " is " + B.name + "'s " + tmp + "Grand Child");
                }
            }
            else
            {
                Console.Write(A.name + " is " + B.name + "'s ");
                if (distance < 2)
                {
                    if (A.gender) Console.Write("Father");
                    else Console.Write("Mother");
                    Console.Write(B.name + " is " + A.name + "'s Child");
                }
                else
                {
                    tmp = "";
                    for (int i = 1; i < distance; i++)
                    {
                        tmp += "Great ";
                    }
                    if (A.gender) Console.Write("Grand Father");
                    else Console.Write("Grand Mother");
                    Console.Write(B.name + " is " + A.name + "'s " + tmp + "Grand Child");
                }
            }
        }
    }
}
