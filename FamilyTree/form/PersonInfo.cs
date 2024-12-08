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
        public List<Person> FamilyMember = new List<Person>();
        Person rootPerson = new Person();
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
            if (mode == "addChild") tmp.addChild(tmp_);
            else if (mode == "addPartner") tmp.addPartner(tmp_);
            this.Close();
        }

        private void btnChoosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\Sample"; // Initial directory
            openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*"; // File filters
            openFileDialog1.FilterIndex = 0; // Default filter selection
            openFileDialog1.RestoreDirectory = true; // Restore the directory last used

            // Show the file dialog and check if the user clicked 'OK'
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return; // Exit if no file was selected
            }

            // Get the selected file's full path
            string selectedFileName = openFileDialog1.FileName;

            // Print the selected file path (you can return it or use it as needed)
            tbFile.Text = selectedFileName;

            FamilyMember = Functions.WriteFamilyToFile(selectedFileName, FamilyMember);
            if (FamilyMember.Count != 0)
                rootPerson = FamilyMember[0];
            // Optionally, you can use the file path further in your code
            // For example, load the file content or display the file path in a UI element.
        }
    }
}
