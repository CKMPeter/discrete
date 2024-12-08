using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FamilyTreeApp
{
    public partial class Test : Form
    {
        TreeNode tmp = new TreeNode();
        public Test(TreeNode A)
        {
            tmp = A;
            InitializeComponent();

        }

        private void Test_Load(object sender, EventArgs e)
        {
            treeViewFamily.Nodes.Add(tmp);
            treeViewFamily.ExpandAll();
        }
    }
}

