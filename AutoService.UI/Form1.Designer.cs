
namespace AutoService.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Orders");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Employees");
            this.informationTextBox = new System.Windows.Forms.RichTextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.getInfoBtn = new System.Windows.Forms.Button();
            this.createOrderBtn = new System.Windows.Forms.Button();
            this.cancelOrderBtn = new System.Windows.Forms.Button();
            this.analysisBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // informationTextBox
            // 
            this.informationTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.informationTextBox.Location = new System.Drawing.Point(398, 12);
            this.informationTextBox.Name = "informationTextBox";
            this.informationTextBox.ReadOnly = true;
            this.informationTextBox.Size = new System.Drawing.Size(390, 426);
            this.informationTextBox.TabIndex = 0;
            this.informationTextBox.Text = "";
            // 
            // treeView
            // 
            this.treeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            treeNode5.Name = "Orders";
            treeNode5.Text = "Orders";
            treeNode6.Name = "Employees";
            treeNode6.Text = "Employees";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.treeView.Size = new System.Drawing.Size(130, 426);
            this.treeView.TabIndex = 1;
            // 
            // getInfoBtn
            // 
            this.getInfoBtn.BackColor = System.Drawing.Color.Bisque;
            this.getInfoBtn.Location = new System.Drawing.Point(148, 57);
            this.getInfoBtn.Name = "getInfoBtn";
            this.getInfoBtn.Size = new System.Drawing.Size(119, 39);
            this.getInfoBtn.TabIndex = 2;
            this.getInfoBtn.Text = "Получить информацию";
            this.getInfoBtn.UseVisualStyleBackColor = false;
            this.getInfoBtn.Click += new System.EventHandler(this.getInfoBtn_Click);
            // 
            // createOrderBtn
            // 
            this.createOrderBtn.BackColor = System.Drawing.Color.Bisque;
            this.createOrderBtn.Location = new System.Drawing.Point(148, 12);
            this.createOrderBtn.Name = "createOrderBtn";
            this.createOrderBtn.Size = new System.Drawing.Size(119, 39);
            this.createOrderBtn.TabIndex = 3;
            this.createOrderBtn.Text = "Создать заказ";
            this.createOrderBtn.UseVisualStyleBackColor = false;
            this.createOrderBtn.Click += new System.EventHandler(this.createOrderBtn_Click);
            // 
            // cancelOrderBtn
            // 
            this.cancelOrderBtn.BackColor = System.Drawing.Color.Bisque;
            this.cancelOrderBtn.Location = new System.Drawing.Point(148, 102);
            this.cancelOrderBtn.Name = "cancelOrderBtn";
            this.cancelOrderBtn.Size = new System.Drawing.Size(119, 39);
            this.cancelOrderBtn.TabIndex = 4;
            this.cancelOrderBtn.Text = "Закрыть заказ";
            this.cancelOrderBtn.UseVisualStyleBackColor = false;
            this.cancelOrderBtn.Click += new System.EventHandler(this.cancelOrderBtn_Click);
            // 
            // analysisBtn
            // 
            this.analysisBtn.BackColor = System.Drawing.Color.Bisque;
            this.analysisBtn.Location = new System.Drawing.Point(148, 147);
            this.analysisBtn.Name = "analysisBtn";
            this.analysisBtn.Size = new System.Drawing.Size(119, 39);
            this.analysisBtn.TabIndex = 5;
            this.analysisBtn.Text = "Провести анализ";
            this.analysisBtn.UseVisualStyleBackColor = false;
            this.analysisBtn.Click += new System.EventHandler(this.analysisBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.analysisBtn);
            this.Controls.Add(this.cancelOrderBtn);
            this.Controls.Add(this.createOrderBtn);
            this.Controls.Add(this.getInfoBtn);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.informationTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox informationTextBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button getInfoBtn;
        private System.Windows.Forms.Button createOrderBtn;
        private System.Windows.Forms.Button cancelOrderBtn;
        private System.Windows.Forms.Button analysisBtn;
    }
}

