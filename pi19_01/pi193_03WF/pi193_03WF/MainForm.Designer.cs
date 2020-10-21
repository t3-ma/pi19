namespace pi193_03WF
{
  partial class MainForm
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
      if (disposing && (components != null)) {
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.listView1 = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.gbLeft = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.button1 = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.panel3 = new System.Windows.Forms.Panel();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.panel2.SuspendLayout();
      this.gbLeft.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel3.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.gbLeft);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(920, 379);
      this.panel1.TabIndex = 3;
      // 
      // groupBox2
      // 
      this.groupBox2.BackColor = System.Drawing.Color.Thistle;
      this.groupBox2.Controls.Add(this.listView1);
      this.groupBox2.Controls.Add(this.panel2);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(200, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(720, 379);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Список сотрудников";
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(3, 89);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(714, 287);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.button3);
      this.panel2.Controls.Add(this.button2);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(3, 16);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(714, 73);
      this.panel2.TabIndex = 1;
      // 
      // button3
      // 
      this.button3.Dock = System.Windows.Forms.DockStyle.Top;
      this.button3.Location = new System.Drawing.Point(0, 23);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(714, 23);
      this.button3.TabIndex = 5;
      this.button3.Text = "Поиск";
      this.button3.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Dock = System.Windows.Forms.DockStyle.Top;
      this.button2.Location = new System.Drawing.Point(0, 0);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(714, 23);
      this.button2.TabIndex = 4;
      this.button2.Text = "Поиск";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // gbLeft
      // 
      this.gbLeft.BackColor = System.Drawing.Color.Coral;
      this.gbLeft.Controls.Add(this.label1);
      this.gbLeft.Controls.Add(this.textBox1);
      this.gbLeft.Controls.Add(this.checkBox1);
      this.gbLeft.Controls.Add(this.button1);
      this.gbLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.gbLeft.Location = new System.Drawing.Point(0, 0);
      this.gbLeft.Name = "gbLeft";
      this.gbLeft.Size = new System.Drawing.Size(200, 379);
      this.gbLeft.TabIndex = 6;
      this.gbLeft.TabStop = false;
      this.gbLeft.Text = "Параметры сотрудника";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "ФИО";
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Location = new System.Drawing.Point(52, 32);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(120, 20);
      this.textBox1.TabIndex = 5;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox1.Location = new System.Drawing.Point(-173, 45);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(80, 17);
      this.checkBox1.TabIndex = 4;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(12, 66);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(118, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "Поиск";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 382);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 267);
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.Color.Orchid;
      this.panel4.Controls.Add(this.radioButton2);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel4.Location = new System.Drawing.Point(463, 3);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(454, 81);
      this.panel4.TabIndex = 1;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(134, 9);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(85, 17);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "radioButton2";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.Orchid;
      this.panel3.Controls.Add(this.radioButton1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(3, 3);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(454, 81);
      this.panel3.TabIndex = 0;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(4, 4);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(85, 17);
      this.radioButton1.TabIndex = 0;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "radioButton1";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(934, 678);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.panel1);
      this.tabPage1.Controls.Add(this.tableLayoutPanel1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(926, 652);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(926, 652);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(934, 678);
      this.Controls.Add(this.tabControl1);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "MainForm";
      this.panel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.gbLeft.ResumeLayout(false);
      this.gbLeft.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox gbLeft;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
  }
}

