using FamilyTreeApp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FamilyTree
{
    public class Functions
    {
        public static bool birthdayFormatChecking(string bDay)
        {
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(bDay);
        }

        public static List<Person> LoadFamilyFromFile(string filePath)
        {
            List<Person> family = new List<Person>();
            Person currentPerson = null;
            string name = "", history = "", parentInfo = "", partnerName = "";
            DateTime birthday = DateTime.MinValue;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("Name:"))
                        {
                            // Add the current person to the family list if they exist
                            if (currentPerson != null)
                            {
                                family.Add(currentPerson);
                            }

                            // Extract the name (everything after "Name:" and before the next field)
                            name = line.Substring(line.IndexOf(":") + 1).Trim();
                            currentPerson = new Person(name, birthday); // Create a new person with the name
                        }
                        else if (line.Contains("DOB:"))
                        {
                            // Extract the date of birth (everything after "DOB:")
                            var dobPart = line.Substring(line.IndexOf(":") + 1).Trim();
                            if (DateTime.TryParse(dobPart, out DateTime parsedDate))
                            {
                                birthday = parsedDate;
                                if (currentPerson != null)
                                    currentPerson.Birthday = birthday;
                            }
                        }
                        else if (line.Contains("Partner:"))
                        {
                            // Extract the partner's name
                            partnerName = line.Substring(line.IndexOf(":") + 1).Trim();
                        }
                        else if (line.Contains("Parent:"))
                        {
                            // Extract the parent(s) info (names after "Parent:")
                            parentInfo = line.Substring(line.IndexOf(":") + 1).Trim();
                        }
                        else if (line.Contains("History:"))
                        {
                            // Extract history information
                            history = line.Substring(line.IndexOf(":") + 1).Trim();
                            if (currentPerson != null)
                                currentPerson.Histoy = history;
                        }
                    }

                    // Add the last person after processing all lines
                    if (currentPerson != null)
                    {
                        family.Add(currentPerson);
                    }

                    // Now associate partners and children
                    foreach (var person in family)
                    {
                        // Find and set the partner
                        if (!string.IsNullOrEmpty(partnerName))
                        {
                            var partner = family.FirstOrDefault(p => p.Name == partnerName);
                            if (partner != null)
                            {
                                person.addPartner(partner);
                            }
                        }

                        // Find and set parents (if any)
                        if (!string.IsNullOrEmpty(parentInfo))
                        {
                            var parents = parentInfo.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var parent in parents)
                            {
                                var parentPerson = family.FirstOrDefault(p => p.Name == parent.Trim());
                                if (parentPerson != null)
                                {
                                    parentPerson.addChild(person);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during file reading
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            return family;
        }

        public static string GetRelationship(Person personA, Person personB)
        {
            if (personA == null || personB == null)
                return "Invalid input. One or both persons are null.";

            // Kiểm tra quan hệ đối tác
            if (personA.Partner == personB)
                return $"{personA.Name} is the partner of {personB.Name}.";

            // Kiểm tra cha mẹ
            if (personA.Children.Contains(personB))
                return $"{personA.Name} is the parent of {personB.Name}.";
            if (personB.Children.Contains(personA))
                return $"{personA.Name} is the child of {personB.Name}.";

            // Kiểm tra ông bà
            foreach (var child in personA.Children)
            {
                if (child.Children.Contains(personB))
                    return $"{personA.Name} is the grandparent of {personB.Name}.";
            }
            foreach (var child in personB.Children)
            {
                if (child.Children.Contains(personA))
                    return $"{personA.Name} is the grandchild of {personB.Name}.";
            }

            // Kiểm tra cụ cố
            foreach (var child in personA.Children)
            {
                foreach (var grandchild in child.Children)
                {
                    if (grandchild.Children.Contains(personB))
                        return $"{personA.Name} is the great-grandparent of {personB.Name}.";
                }
            }
            foreach (var child in personB.Children)
            {
                foreach (var grandchild in child.Children)
                {
                    if (grandchild.Children.Contains(personA))
                        return $"{personA.Name} is the great-grandchild of {personB.Name}.";
                }
            }

            // Kiểm tra anh/chị/em ruột
            if (personA.Partner != null && personB.Partner != null)
            {
                foreach (var sibling in personA.Children)
                {
                    if (sibling == personB)
                        return $"{personA.Name} and {personB.Name} are siblings.";
                }
            }

            return $"{personA.Name} and {personB.Name} have no direct relationship.";
        }

        public static Person FindPerson(string name, string dob, List<Person> familyMembers)
        {
            // Chuyển ngày sinh từ chuỗi thành DateTime
            DateTime birthDay = DateTime.Parse(dob, new CultureInfo("en-GB"));

            // Duyệt qua danh sách các thành viên để tìm kiếm
            foreach (var person in familyMembers)
            {
                if (person.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && person.Birthday == birthDay)
                {
                    return person; // Trả về đối tượng Person nếu tìm thấy
                }
            }

            // Trả về null nếu không tìm thấy
            return null;
        }

    }
}
