using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace discrete_graph_c_
{
    public class Functions
    {
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
            Console.Write($"(");
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
    }
}
