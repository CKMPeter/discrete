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
        public string PersonID { get; set; }
        public Person[] parent = new Person[2];
        public string name { get; set; }
        public DateTime bDay { get; set; }
        public Person partner { get; set; }
        public List<Person> child{ get; set; }
        public int step { get; set; }
        public bool gender { get; set; }
        // Constructor
        public Person(string name, DateTime bDay, Person partner, List<Person> child, Person[] parents, int step, bool gender)
        {
            this.step = step;
            this.parent = parents;
            this.name = name;
            this.bDay = bDay;
            this.partner = partner;
            this.child = child;
            this.PersonID = createID();
            this.gender = gender;
        }
        public Person(string name, int step, bool gender)
        {
            this.step = step;
            this.name = name;
            this.bDay = bDay;
            this.partner = new Person();
            this.child = new List<Person>();
            this.parent = new Person[2];
            this.PersonID = createID();
            this.gender = gender;
        }
        public Person(string name, DateTime bDay, int step, bool gender)
        {
            this.step = step;
            this.name = name;
            this.bDay = bDay;
            this.partner = new Person();
            this.child = new List<Person>();
            this.parent = new Person[2];
            this.PersonID = createID();
            this.gender = gender;
        }
        public Person()
        {
            this.step = -1;
            this.name = "";
            this.bDay = default(DateTime);
            this.partner = null;
            this.child = new List<Person>();
            this.parent = null;
            this.PersonID = createID();
            this.gender = true;
        }

        // Function
        public void addChild(Person child)
        {
            if (this.partner == null) return;
            //if (child.bDay.Year - this.bDay.Year < 0)
            //{
            //    return;
            //}
            this.child.Add(child);
            this.partner.child.Add(child);
            child.parent[0] = this;
            child.parent[1] = this.partner;
            child.step = this.step + 1;
            if (child.partner != null)
            {
                child.partner.parent= child.parent;
                child.partner.step = this.step + 1;
            }
            return;
        }
        public void addPersonConnection(Person A)
        {
            if (this.partner != null) return;
            this.partner = A;
            return;
        }
        public void removeChild(Person child)
        {
            if (child == null || this.child == null || this.partner == null)
                return;

            // Remove the child from the current parent's list of children
            if (this.child.Contains(child))
            {
                this.child.Remove(child);
            }
            // Remove the child from the partner's list of children
            if (this.partner.child.Contains(child))
            {
                this.partner.child.Remove(child);
            }
            // Clear the parent references in the child
            if (child.parent != null)
            {
                if (child.parent[0] == this) child.parent[0] = null; // Clear reference to this parent
                if (child.parent[1] == this.partner) child.parent[1] = null; // Clear reference to the partner
            }
            child.step = 0;
            // If the child has a partner, clear the partner's parent reference
            if (child.partner != null)
            {
                child.partner.parent = null; // Clear the parent's reference
                child.partner.step = 0; // Reset step if needed
            }
        }
        public void removePersonConnection(Person A)
        {
            if (this.partner == A)  this.partner = null;
            if (A.partner == this)  A.partner = null;
            return;
        }
        public string createID()
        {
            DateTime dateTime = this.bDay;
            string tmp = dateTime.ToString("ddMMyy");
            string tmp_ = "";
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == '/')
                {
                    continue;
                }
                tmp_ += tmp[i];
            }
            tmp_ = this.name + tmp_ + this.step;
            return tmp_;
        }
    }
}
