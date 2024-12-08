using System.Drawing;
using System;

namespace FamilyTreeApp
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.TreeView familyTreeView;

        private void InitializeComponent()
        {
            this.familyTreeView = new System.Windows.Forms.TreeView();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnAddPartner = new System.Windows.Forms.Button();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.btnVisuallize = new System.Windows.Forms.Button();
            this.btnSampleStructure = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.lbCurrentSelectPerson = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.tbChildCount = new System.Windows.Forms.TextBox();
            this.tbDob = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // familyTreeView
            // 
            this.familyTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familyTreeView.Location = new System.Drawing.Point(12, 28);
            this.familyTreeView.Name = "familyTreeView";
            this.familyTreeView.Size = new System.Drawing.Size(300, 462);
            this.familyTreeView.TabIndex = 0;
            this.familyTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.familyTreeView_AfterSelect);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChild.Location = new System.Drawing.Point(786, 100);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(154, 60);
            this.btnAddChild.TabIndex = 2;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnAddPartner
            // 
            this.btnAddPartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPartner.Location = new System.Drawing.Point(786, 166);
            this.btnAddPartner.Name = "btnAddPartner";
            this.btnAddPartner.Size = new System.Drawing.Size(154, 60);
            this.btnAddPartner.TabIndex = 3;
            this.btnAddPartner.Text = "Add Partner";
            this.btnAddPartner.UseVisualStyleBackColor = true;
            this.btnAddPartner.Click += new System.EventHandler(this.btnAddPartner_Click);
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInfo.Location = new System.Drawing.Point(786, 232);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(154, 60);
            this.btnUpdateInfo.TabIndex = 4;
            this.btnUpdateInfo.Text = "Update Infomation";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // btnVisuallize
            // 
            this.btnVisuallize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisuallize.Location = new System.Drawing.Point(786, 298);
            this.btnVisuallize.Name = "btnVisuallize";
            this.btnVisuallize.Size = new System.Drawing.Size(154, 60);
            this.btnVisuallize.TabIndex = 5;
            this.btnVisuallize.Text = "Visualization";
            this.btnVisuallize.UseVisualStyleBackColor = true;
            this.btnVisuallize.Click += new System.EventHandler(this.btnVisuallize_Click);
            // 
            // btnSampleStructure
            // 
            this.btnSampleStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSampleStructure.Location = new System.Drawing.Point(786, 364);
            this.btnSampleStructure.Name = "btnSampleStructure";
            this.btnSampleStructure.Size = new System.Drawing.Size(154, 60);
            this.btnSampleStructure.TabIndex = 6;
            this.btnSampleStructure.Text = "Sample Structure";
            this.btnSampleStructure.UseVisualStyleBackColor = true;
            this.btnSampleStructure.Click += new System.EventHandler(this.btnSampleStructure_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.Location = new System.Drawing.Point(786, 430);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(154, 60);
            this.btnChooseFile.TabIndex = 7;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // lbCurrentSelectPerson
            // 
            this.lbCurrentSelectPerson.AutoSize = true;
            this.lbCurrentSelectPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentSelectPerson.Location = new System.Drawing.Point(318, 47);
            this.lbCurrentSelectPerson.Name = "lbCurrentSelectPerson";
            this.lbCurrentSelectPerson.Size = new System.Drawing.Size(493, 51);
            this.lbCurrentSelectPerson.TabIndex = 8;
            this.lbCurrentSelectPerson.Text = "Current Selected Person";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbHistory);
            this.panel1.Controls.Add(this.tbChildCount);
            this.panel1.Controls.Add(this.tbDob);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(318, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 388);
            this.panel1.TabIndex = 10;
            // 
            // tbHistory
            // 
            this.tbHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHistory.Location = new System.Drawing.Point(149, 225);
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.Size = new System.Drawing.Size(300, 34);
            this.tbHistory.TabIndex = 7;
            // 
            // tbChildCount
            // 
            this.tbChildCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChildCount.Location = new System.Drawing.Point(149, 165);
            this.tbChildCount.Name = "tbChildCount";
            this.tbChildCount.Size = new System.Drawing.Size(300, 34);
            this.tbChildCount.TabIndex = 6;
            // 
            // tbDob
            // 
            this.tbDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDob.Location = new System.Drawing.Point(149, 93);
            this.tbDob.Name = "tbDob";
            this.tbDob.Size = new System.Drawing.Size(300, 34);
            this.tbDob.TabIndex = 5;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(149, 27);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(300, 34);
            this.tbName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "History:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dob:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Child count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // lbFilePath
            // 
            this.lbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilePath.Location = new System.Drawing.Point(611, 511);
            this.lbFilePath.MaximumSize = new System.Drawing.Size(300, 40);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(0, 38);
            this.lbFilePath.TabIndex = 11;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(952, 573);
            this.Controls.Add(this.lbFilePath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbCurrentSelectPerson);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.btnSampleStructure);
            this.Controls.Add(this.btnVisuallize);
            this.Controls.Add(this.btnUpdateInfo);
            this.Controls.Add(this.btnAddPartner);
            this.Controls.Add(this.btnAddChild);
            this.Controls.Add(this.familyTreeView);
            this.Name = "Main";
            this.Text = "Family Tree Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnAddPartner;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Button btnVisuallize;
        private System.Windows.Forms.Button btnSampleStructure;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label lbCurrentSelectPerson;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbChildCount;
        private System.Windows.Forms.TextBox tbDob;
        private System.Windows.Forms.TextBox tbHistory;
        private System.Windows.Forms.Label lbFilePath;
    }
}

