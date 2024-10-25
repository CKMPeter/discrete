using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discrete_graph_c_
{ 
    public class Person
    {
        public Person[] parent = new Person[2];
        public string name { get; set; }
        public DateTime bDay { get; set; }
        public Person partner { get; set; }
        public List<Person> child{ get; set; }

        // Constructor
        public Person(string name, DateTime bDay, Person partner, List<Person> child, Person[] parents)
        {
            this.parent = parents;
            this.name = name;
            this.bDay = bDay;
            this.partner = partner;
            this.child = child;
        }
        public Person()
        {
            this.name = "";
            this.bDay = default(DateTime);
            this.partner = null;
            this.child = new List<Person>();
            this.parent = null;
        }

        // Function
        public void addChild(Person child)
        {
            if (this.partner == null) return;
            if (child.bDay.Year - this.bDay.Year < 0)
            {
                return;
            }
            this.child.Add(child);
            return;
        }
        public void addPersonConnection(Person A)
        {
            if (this.partner != null) return;
            this.partner = A;
            return;
        }
    }
}
