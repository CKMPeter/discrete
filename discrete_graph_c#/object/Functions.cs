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
                                A = A + c + count;
                            }
                            else if (char.IsLetterOrDigit(c) || c == '(' || c == ')' || c == '/') // Check for alphanumeric or parentheses
                            {
                                A += c;
                            }
                        }
                        lines.Add(count + A);
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
                using (StreamWriter wt = new StreamWriter(pth))
                {
                    foreach (Person person in randomPerson)
                    {
                        // Skip if the person's partner has already been checked
                        if (person.partner != null && checkedList.Contains(person.partner))
                            continue;
                        checkedList.Add(person);
                        int gender, gender_;
                        gender = gender_ = 0;
                        if (person.gender) gender = 1;
                        if (person.partner.gender) gender_ = 1;
                        if (person.bDay != default(DateTime)) wt.Write(new string('-', person.step) + person.name + "(" + person.bDay.Date.ToString("dd/MM/yyyy") + ")" + gender + ",");
                        else wt.Write(new string('-', person.step) + person.name + "()" + gender + ",");
                        if (person.partner != null)
                        {
                            if (person.partner.bDay != default(DateTime)) wt.WriteLine(person.partner.name + "(" + person.partner.bDay.Date.ToString("dd/MM/yyyy") + ")" + gender_);
                            else wt.WriteLine(person.partner.name + "()" + gender_);
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
            } else Console.Write(")");

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
            List<Person> list = new List<Person>();
            int step;
            string name, dob;
            bool gender;
            int flag = 0;
            foreach (string line in lines)
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
                                if (flag == 0) name += line[j];
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
                                if (flag == 0) dob = line[m] + dob;
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
                //tmp.addChild(person.partner);
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
                Console.WriteLine("Name: " + person.name + "| | ID: " + person.PersonID + "| | Parent: "+ person.parent[0].name );
            }
        }

        public static void DetermineRelationship(Person person1, Person person2)
        {
            string role = "";
            if (person1.child.Contains(person2))
            {
                if (person1.gender)
                {
                    role = "father";
                }
                else role = "mother";
                Console.WriteLine($"{person1.name} is a ({role}) of {person2.name}.");
            }
            else if (person2.child.Contains(person1))
            {
                Console.WriteLine($"{person1.name} is a child of {person2.name}.");
            }
            else if ((person1.parent != null && (person1.parent[0] == person2 || person1.parent[1] == person2)) ||
                     (person2.parent != null && (person2.parent[0] == person1 || person2.parent[1] == person1)))
            {
                Console.WriteLine($"{person1.name } and {person2.name} are siblings.");
            }
            else
            {
                Console.WriteLine($"{person1.name} and {person2.name} have no direct relationship.");
            }
        }

        public static void printListPerson(List<Person> randomPerson)
        {
            foreach (Person person in randomPerson)
            {
                Console.WriteLine(person.name + " " + person.bDay.ToString("dd/MM/yyyy") + " " + person.PersonID);
            }
        }

        public static void printFamilyTree(Person member, string prefix = "", bool isLast = true)
        {
            // In tên của thành viên hiện tại
            Console.WriteLine(prefix + (isLast ? "└── " : "├── ") + member.name + ", " + member.partner.name);

            // Tạo prefix cho các con
            prefix += isLast ? "    " : "│   ";

            // Duyệt qua danh sách các con
            for (int i = 0; i < member.child.Count; i++)
            {
                printFamilyTree(member.child[i], prefix, i == member.child.Count - 1);
            }
        }

        public static int GetTreeWidth(Person member)
        {
            if (member.child.Count == 0) return 1;

            int width = 0;
            foreach (var child in member.child)
            {
                width += GetTreeWidth(child);
            }
            return width;
        }
        // Hàm đệ quy để in cây gia phả ở giữa console
        public static void PrintFamilyTreeCentered(Person member, int depth = 0, int position = 40, int parentWidth = 80)
        {
            // Get parent's and partner's details

            string birthDate = member.bDay.Year > 1 ? member.bDay.ToString("dd-MM-yyyy") : "N/A";
            string partnerInfo = member.partner != null
                ? $" - {member.partner.name} ({(member.partner.bDay.Year > 1 ? member.partner.bDay.ToString("dd-MM-yyyy") : "N/A")})"
                : "";

            // Print parent and partner
            Console.SetCursorPosition(position, depth * 3);
            Console.WriteLine($"{member.name} ({birthDate}){partnerInfo}");

            // If no children, return
            if (member.child == null || member.child.Count == 0) return;

            // Calculate total width for children
            int totalWidth = GetTreeWidth(member);
            int step = parentWidth / totalWidth;

            // Initial position for children
            int currentPosition = position - (totalWidth - 1) * step / 2;

            // Draw vertical line from parent to children
            Console.SetCursorPosition(position, depth * 3 + 1);
            Console.Write("|");

            // Iterate over children
            foreach (var child in member.child)
            {
                int childTreeWidth = GetTreeWidth(child);
                int childPosition = currentPosition + (childTreeWidth - 1) * step / 2;

                // Horizontal line connecting parent to child
                int start = Math.Min(position, childPosition);
                int end = Math.Max(position, childPosition);

                for (int x = start; x <= end; x++)
                {
                    Console.SetCursorPosition(x, depth * 3 + 2);
                    Console.Write("-");
                }

                // Vertical line below the child
                Console.SetCursorPosition(childPosition, depth * 3 + 3);
                Console.Write("|");

                // Recursively print the child's subtree
                PrintFamilyTreeCentered(child, depth + 1, childPosition, step * childTreeWidth);

                // Add a buffer space after this child's branch
                currentPosition += step * childTreeWidth + step / 2;
            }
        }
    }
}
