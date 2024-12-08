using System.Windows.Forms;

namespace FamilyTreeApp
{
    partial class Test
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtFather;
        private TextBox txtMother;
        private TextBox txtChildren;
        private Button btnGenerateTree;
        private TreeView treeViewFamily;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFather = new System.Windows.Forms.TextBox();
            this.txtMother = new System.Windows.Forms.TextBox();
            this.txtChildren = new System.Windows.Forms.TextBox();
            this.btnGenerateTree = new System.Windows.Forms.Button();
            this.treeViewFamily = new System.Windows.Forms.TreeView();
            this.SuspendLayout();

            // Name TextBox
            this.txtName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 0;

            // Father TextBox
            this.txtFather.Location = new System.Drawing.Point(20, 60);
            this.txtFather.Name = "txtFather";
            this.txtFather.Size = new System.Drawing.Size(200, 23);
            this.txtFather.TabIndex = 1;

            // Mother TextBox
            this.txtMother.Location = new System.Drawing.Point(20, 100);
            this.txtMother.Name = "txtMother";
            this.txtMother.Size = new System.Drawing.Size(200, 23);
            this.txtMother.TabIndex = 2;

            // Children TextBox
            this.txtChildren.Location = new System.Drawing.Point(20, 140);
            this.txtChildren.Name = "txtChildren";
            this.txtChildren.Size = new System.Drawing.Size(200, 23);
            this.txtChildren.TabIndex = 3;

            // Generate Tree Button
            this.btnGenerateTree.Location = new System.Drawing.Point(20, 180);
            this.btnGenerateTree.Name = "btnGenerateTree";
            this.btnGenerateTree.Size = new System.Drawing.Size(200, 30);
            this.btnGenerateTree.TabIndex = 4;
            this.btnGenerateTree.Text = "Tạo cây gia phả";
            this.btnGenerateTree.UseVisualStyleBackColor = true;
            this.btnGenerateTree.Click += new System.EventHandler(this.btnGenerateTree_Click);

            // Family TreeView
            this.treeViewFamily.Location = new System.Drawing.Point(250, 20);
            this.treeViewFamily.Name = "treeViewFamily";
            this.treeViewFamily.Size = new System.Drawing.Size(300, 300);
            this.treeViewFamily.TabIndex = 5;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.treeViewFamily);
            this.Controls.Add(this.btnGenerateTree);
            this.Controls.Add(this.txtChildren);
            this.Controls.Add(this.txtMother);
            this.Controls.Add(this.txtFather);
            this.Controls.Add(this.txtName);
            this.Name = "MainForm";
            this.Text = "Cây Gia Phả";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
