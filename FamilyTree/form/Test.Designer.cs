using System.Windows.Forms;

namespace FamilyTreeApp
{
    partial class Test
    {
        private System.ComponentModel.IContainer components = null;
        private TreeView treeViewFamily;

        private void InitializeComponent()
        {
            this.treeViewFamily = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewFamily
            // 
            this.treeViewFamily.Location = new System.Drawing.Point(12, 12);
            this.treeViewFamily.Name = "treeViewFamily";
            this.treeViewFamily.Size = new System.Drawing.Size(342, 320);
            this.treeViewFamily.TabIndex = 5;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 373);
            this.Controls.Add(this.treeViewFamily);
            this.Name = "Test";
            this.Text = "Cây Gia Phả";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }
    }
}
