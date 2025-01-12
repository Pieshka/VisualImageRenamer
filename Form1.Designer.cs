namespace VisualImageRename
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPreviewPB = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.shiftLeftB = new System.Windows.Forms.Button();
            this.shiftRightB = new System.Windows.Forms.Button();
            this.imageSelectFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.renameStartB = new System.Windows.Forms.Button();
            this.loadFromDirectoryB = new System.Windows.Forms.Button();
            this.applyToAllB = new System.Windows.Forms.Button();
            this.fileNameTB = new System.Windows.Forms.TextBox();
            this.fileNameL = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPreviewPB)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.mainPreviewPB, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // mainPreviewPB
            // 
            this.mainPreviewPB.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.mainPreviewPB, "mainPreviewPB");
            this.mainPreviewPB.Name = "mainPreviewPB";
            this.mainPreviewPB.TabStop = false;
            this.mainPreviewPB.DoubleClick += new System.EventHandler(this.mainPreviewPB_DoubleClick);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.shiftLeftB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.shiftRightB, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.imageSelectFLP, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // shiftLeftB
            // 
            resources.ApplyResources(this.shiftLeftB, "shiftLeftB");
            this.shiftLeftB.Name = "shiftLeftB";
            this.shiftLeftB.UseVisualStyleBackColor = true;
            this.shiftLeftB.Click += new System.EventHandler(this.shiftLeftB_Click);
            // 
            // shiftRightB
            // 
            resources.ApplyResources(this.shiftRightB, "shiftRightB");
            this.shiftRightB.Name = "shiftRightB";
            this.shiftRightB.UseVisualStyleBackColor = true;
            this.shiftRightB.Click += new System.EventHandler(this.shiftRightB_Click);
            // 
            // imageSelectFLP
            // 
            resources.ApplyResources(this.imageSelectFLP, "imageSelectFLP");
            this.imageSelectFLP.BackColor = System.Drawing.SystemColors.ControlDark;
            this.imageSelectFLP.Name = "imageSelectFLP";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.renameStartB);
            this.panel1.Controls.Add(this.loadFromDirectoryB);
            this.panel1.Controls.Add(this.applyToAllB);
            this.panel1.Controls.Add(this.fileNameTB);
            this.panel1.Controls.Add(this.fileNameL);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // renameStartB
            // 
            resources.ApplyResources(this.renameStartB, "renameStartB");
            this.renameStartB.Name = "renameStartB";
            this.renameStartB.UseVisualStyleBackColor = true;
            this.renameStartB.Click += new System.EventHandler(this.renameStartB_Click);
            // 
            // loadFromDirectoryB
            // 
            resources.ApplyResources(this.loadFromDirectoryB, "loadFromDirectoryB");
            this.loadFromDirectoryB.Name = "loadFromDirectoryB";
            this.loadFromDirectoryB.UseVisualStyleBackColor = true;
            this.loadFromDirectoryB.Click += new System.EventHandler(this.loadFromDirectoryB_Click);
            // 
            // applyToAllB
            // 
            resources.ApplyResources(this.applyToAllB, "applyToAllB");
            this.applyToAllB.Name = "applyToAllB";
            this.applyToAllB.UseVisualStyleBackColor = true;
            this.applyToAllB.Click += new System.EventHandler(this.applyToAllB_Click);
            // 
            // fileNameTB
            // 
            resources.ApplyResources(this.fileNameTB, "fileNameTB");
            this.fileNameTB.Name = "fileNameTB";
            this.toolTip1.SetToolTip(this.fileNameTB, resources.GetString("fileNameTB.ToolTip"));
            this.fileNameTB.TextChanged += new System.EventHandler(this.fileNameTB_TextChanged);
            // 
            // fileNameL
            // 
            resources.ApplyResources(this.fileNameL, "fileNameL");
            this.fileNameL.Name = "fileNameL";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "Help";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPreviewPB)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button renameStartB;

        private System.Windows.Forms.Button applyToAllB;

        private System.Windows.Forms.Button loadFromDirectoryB;

        private System.Windows.Forms.TextBox fileNameTB;

        private System.Windows.Forms.Label fileNameL;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.FlowLayoutPanel imageSelectFLP;

        private System.Windows.Forms.Button shiftRightB;

        private System.Windows.Forms.Button shiftLeftB;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.PictureBox mainPreviewPB;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}