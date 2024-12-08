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
        public static List<Person> WriteFamilyToFile(string filePath, List<Person> family)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Person person in family)
                    {
                        string partnerInfor = !string.IsNullOrEmpty(person.Partner?.Name)
                            ? $"Partner: {person.Partner.Name}" : "";
                        string line = $"Name: {person.Name}\n" +
                                      $"DOB: {person.Birthday.ToShortDateString()}\n" +
                                      $"History: {person.Histoy}" + partnerInfor;
                        writer.WriteLine(line);
                        writer.WriteLine("===============================================");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during file reading
                Console.WriteLine("Error Writing file: " + ex.Message);
            }

            return family;
        }
        public static List<Person> LoadFamilyFromFile(string filePath)
        {
            List<Person> family = new List<Person>();
            Person currentPerson = null;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Name:"))
                        {
                            // Add the current person to the family list if they exist
                            if (currentPerson != null)
                            {
                                family.Add(currentPerson);
                            }

                            // Extract the name
                            string name = line.Substring(line.IndexOf(":") + 1).Trim();
                            currentPerson = new Person(name, DateTime.MinValue); // Create a new person with the name
                        }
                        else if (line.StartsWith("DOB:"))
                        {
                            var dobPart = line.Substring(line.IndexOf(":") + 1).Trim();
                            if (DateTime.TryParseExact(dobPart, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                            {
                                if (currentPerson != null)
                                {
                                    currentPerson.Birthday = parsedDate;
                                }
                            }
                        }
                        else if (line.StartsWith("Partner:"))
                        {
                            // Extract the partner's name
                            string partnerName = line.Substring(line.IndexOf(":") + 1).Trim();
                            if (currentPerson != null)
                            {
                                var partner = family.FirstOrDefault(p => p.Name == partnerName);
                                if (partner != null)
                                {
                                    currentPerson.addPartner(partner);
                                }
                            }
                        }
                        else if (line.StartsWith("Parent:"))
                        {
                            // Extract the parent(s) info
                            string parentInfo = line.Substring(line.IndexOf(":") + 1).Trim();
                            if (currentPerson != null)
                            {
                                var parents = parentInfo.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var parentName in parents)
                                {
                                    var parent = family.FirstOrDefault(p => p.Name == parentName.Trim());
                                    if (parent != null)
                                    {
                                        parent.addChild(currentPerson);
                                    }
                                }
                            }
                        }
                        else if (line.StartsWith("History:"))
                        {
                            // Extract history information
                            string history = line.Substring(line.IndexOf(":") + 1).Trim();
                            if (currentPerson != null)
                            {
                                currentPerson.Histoy = history;
                            }
                        }
                    }

                    // Add the last person after processing all lines
                    if (currentPerson != null)
                    {
                        family.Add(currentPerson);
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
