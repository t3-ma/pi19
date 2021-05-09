namespace WindowsFormsApp1
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
      this.label1 = new System.Windows.Forms.Label();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.txtAddr = new System.Windows.Forms.TextBox();
      this.lvParts = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lvArticles = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(309, 110);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 0;
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.button2.Location = new System.Drawing.Point(1, 279);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(80, 35);
      this.button2.TabIndex = 3;
      this.button2.Text = "Проверить подключение";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.button1.Location = new System.Drawing.Point(192, 11);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(148, 22);
      this.button1.TabIndex = 4;
      this.button1.Text = "Обновить список разделов";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // txtAddr
      // 
      this.txtAddr.Location = new System.Drawing.Point(12, 12);
      this.txtAddr.Name = "txtAddr";
      this.txtAddr.Size = new System.Drawing.Size(181, 20);
      this.txtAddr.TabIndex = 5;
      // 
      // lvParts
      // 
      this.lvParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.lvParts.HideSelection = false;
      this.lvParts.Location = new System.Drawing.Point(12, 38);
      this.lvParts.Name = "lvParts";
      this.lvParts.Size = new System.Drawing.Size(328, 97);
      this.lvParts.TabIndex = 8;
      this.lvParts.UseCompatibleStateImageBehavior = false;
      this.lvParts.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Раздел";
      this.columnHeader1.Width = 252;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Количество";
      this.columnHeader2.Width = 72;
      // 
      // lvArticles
      // 
      this.lvArticles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
      this.lvArticles.HideSelection = false;
      this.lvArticles.Location = new System.Drawing.Point(12, 141);
      this.lvArticles.Name = "lvArticles";
      this.lvArticles.Size = new System.Drawing.Size(328, 97);
      this.lvArticles.TabIndex = 9;
      this.lvArticles.UseCompatibleStateImageBehavior = false;
      this.lvArticles.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Слово";
      this.columnHeader3.Width = 161;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Значение";
      this.columnHeader4.Width = 161;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(740, 315);
      this.Controls.Add(this.lvArticles);
      this.Controls.Add(this.lvParts);
      this.Controls.Add(this.txtAddr);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "Client";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtAddr;
    private System.Windows.Forms.ListView lvParts;
    private System.Windows.Forms.ListView lvArticles;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
  }
}

