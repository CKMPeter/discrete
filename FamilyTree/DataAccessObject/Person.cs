using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilyTreeApp
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Person Partner { get; set; }
        public List<Person> Children { get; set; }
        public Image Photo { get; set; }

        public string Histoy {  get; set; }

        public string id { get; set; }

        public Person()
        {
           
        }
        public Person(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
            Histoy = "";
            Children = new List<Person>();
        }
        public Person(string name, DateTime birthday, string history)
        {
            Name = name;
            Birthday = birthday;
            Histoy = history;
            Children = new List<Person>();
        }
        public Person(string name, Image photo)
        {
            Name = name;
            Photo = photo;
            Histoy = "";
            Children = new List<Person>();
        }

        public void addPartner(Person A)
        {
            this.Partner = A;
            A.Partner = this;
        }

        public void addChild(Person A)
        {
            this.Children.Add(A);
        }
    }
}