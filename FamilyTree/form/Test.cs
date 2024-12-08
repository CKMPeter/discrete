using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FamilyTreeApp
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
           
        }

        private void btnGenerateTree_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu cũ trong TreeView
            treeViewFamily.Nodes.Clear();

            // Lấy dữ liệu từ các TextBox
            string name = txtName.Text.Trim();
            string father = txtFather.Text.Trim();
            string mother = txtMother.Text.Trim();
            string[] children = txtChildren.Text.Split(',');

            // Tạo nút gốc cho cây (tên người)
            TreeNode rootNode = new TreeNode(name);

            // Thêm cha và mẹ
            if (!string.IsNullOrEmpty(father))
            {
                TreeNode fatherNode = new TreeNode($"Cha: {father}");
                rootNode.Nodes.Add(fatherNode);
            }
            if (!string.IsNullOrEmpty(mother))
            {
                TreeNode motherNode = new TreeNode($"Mẹ: {mother}");
                rootNode.Nodes.Add(motherNode);
            }

            // Thêm danh sách con cái
            if (children.Length > 0 && !string.IsNullOrWhiteSpace(children[0]))
            {
                TreeNode childrenNode = new TreeNode("Con cái:");
                foreach (string child in children)
                {
                    if (!string.IsNullOrWhiteSpace(child))
                    {
                        childrenNode.Nodes.Add(new TreeNode(child.Trim()));
                    }
                }
                rootNode.Nodes.Add(childrenNode);
            }

            // Thêm nút gốc vào TreeView
            treeViewFamily.Nodes.Add(rootNode);

            // Mở rộng tất cả các nhánh để dễ nhìn
            treeViewFamily.ExpandAll();
        }

         

            
    }
}

