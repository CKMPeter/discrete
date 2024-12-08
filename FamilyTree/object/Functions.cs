using FamilyTreeApp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

    }
}
