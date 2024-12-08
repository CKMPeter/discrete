using FamilyTreeApp;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree.form
{
    public partial class PersonInfo : Form
    {
        Main main = Program.main;
        Person tmp = new Person();
        string mode = "";
        public PersonInfo(Person person, string mode)
        {
            if (person == null) return;
            this.tmp = person;
            this.mode = mode;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Person tmp_ = new Person();
            if (tbName.Text == "") return;
            {
                if (tbDob.Text != "" && Functions.birthdayFormatChecking(tbDob.Text))
                {
                    DateTime birthDay = DateTime.Parse(tbDob.Text, new CultureInfo("en-GB"));
                    tmp_ = new Person(tbName.Text, birthDay);
                }
            }
            if (mode == "addChild") { tmp.addChild(tmp_); this.Close(); }
            else if (mode == "addPartner") { tmp.addPartner(tmp_); this.Close(); }
            else if (mode == "relationCheckin")
            {
                btnCreate.Text = "Check";
                Person select = Functions.FindPerson(tbName.Text.Trim(), tbDob.Text.Trim(), main.FamilyMember);
                Console.WriteLine(tmp.Name, select.Name);
                lbRelationChecking.Text = Functions.GetRelationship(tmp, select);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
