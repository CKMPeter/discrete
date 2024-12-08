using FamilyTree;
using FamilyTree.form;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FamilyTreeApp
{
    public partial class Main : Form
    {
        public List<Person> FamilyMember = new List<Person>();
        public Person currentPerson { get; set; }

        Person rootPerson = new Person();
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create sample family data
        }

        private void BuildFamilyTree(TreeNode treeNode, Person person)
        {
            if (person == null) return;

            // Create a node for the person
            TreeNode personNode = new TreeNode(person.Name)
            {
                Tag = person
            };
            treeNode.Nodes.Add(personNode);

            // Create a node for the partner if they exist
            if (person.Partner != null)
            {
                TreeNode partnerNode = new TreeNode("Partner: " + person.Partner.Name)
                {
                    Tag = person.Partner
                };
                personNode.Nodes.Add(partnerNode);
            }

            // Add children to the tree if they exist
            if (person.Children != null && person.Children.Count > 0)
            {
                TreeNode childrenNode = new TreeNode("Children of " + person.Name); // Only one "Children of [Parent Name]" node
                personNode.Nodes.Add(childrenNode);
                foreach (var child in person.Children)
                {
                    BuildFamilyTree(childrenNode, child);

                }
                // Add the "Children of" node to the treeNode
            }
        }



        private void familyTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Person selectedPerson)
            {
                currentPerson = selectedPerson;
                tbName.Text = currentPerson.Name;
                tbDob.Text = currentPerson.Birthday.ToString("dd/MM/yyyy");
                tbChildCount.Text = currentPerson.Children.Count.ToString();
                tbHistory.Text= currentPerson.Histoy;

            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(currentPerson, "addChild");
            personInfo.Show();
        }

        private void btnSampleStructure_Click(object sender, EventArgs e)
        {
            rootPerson = new Person("John", new DateTime(1960, 1, 1));
            var partner = new Person("Mary", new DateTime(1965, 2, 15));
            rootPerson.addPartner(partner);

            var child1 = new Person("Anna", new DateTime(1990, 3, 10));
            var parner1 = new Person("Mike", new DateTime(1990, 3, 10));
            child1.addPartner(parner1);
            var child2 = new Person("Michael", new DateTime(1993, 5, 25));
            rootPerson.Children.AddRange(new[] { child1, child2 });


            FamilyMember.AddRange(new[] { rootPerson, partner, child1, parner1, child2 });
            // Add to TreeView
            TreeNode rootNode = new TreeNode("Family Root");
            BuildFamilyTree(rootNode, rootPerson);

            familyTreeView.Nodes.Add(rootNode);
            familyTreeView.ExpandAll();

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
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
            lbFilePath.Text = selectedFileName;

            FamilyMember = Functions.LoadFamilyFromFile(selectedFileName);
            if( FamilyMember.Count != 0)
                rootPerson = FamilyMember[0];
            // Optionally, you can use the file path further in your code
            // For example, load the file content or display the file path in a UI element.
        }


        private void btnAddPartner_Click(object sender, EventArgs e)
        {
            PersonInfo partner = new PersonInfo(currentPerson, "addPartner");
            partner.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DebugRootPerson(rootPerson); // Check if the family data exists

            familyTreeView.Nodes.Clear(); // Clear the current tree structure
            TreeNode rootNode = new TreeNode("Family Root");
            BuildFamilyTree(rootNode, rootPerson);

            familyTreeView.Nodes.Add(rootNode);
            familyTreeView.ExpandAll();
        }


        private void DebugRootPerson(Person rootPerson)
        {
            if (rootPerson == null)
            {
                Console.WriteLine("rootPerson is null!");
                return;
            }

            Console.WriteLine($"Root: {rootPerson.Name}");
            foreach (var child in rootPerson.Children)
            {
                Console.WriteLine($"Child: {child.Name}");
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            currentPerson.Name = tbName.Text;
            if(tbDob.Text != null && Functions.birthdayFormatChecking(tbDob.Text))
            {
                DateTime birthDay = DateTime.Parse(tbDob.Text, new CultureInfo("en-GB"));
                currentPerson.Birthday = birthDay;
            }
            if(tbHistory.Text != "") currentPerson.Histoy = tbHistory.Text;
        }

        private void btnVisuallize_Click(object sender, EventArgs e)
        {
            Visualization newForm = new Visualization(rootPerson);
            newForm.Show();
        }
    }
}