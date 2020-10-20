using pi191_03CL.Model;
using pi191_03CL.ModelXO;
using System;
using System.Windows.Forms;

namespace pi191_03WF
{
  public partial class MainForm : Form
  {
    #region private variables
    private readonly TestMailServer m_pMailServer;
    private readonly Field m_pField;
    #endregion

    #region constructor
    public MainForm(TestMailServer pMailServer)
    {
      m_pMailServer = pMailServer;
      m_pField = new Field();
      InitializeComponent();
      h_FillForm();
      h_CreateButtonField();
      h_RefreshButtonField();
    }

    #endregion


    #region private methods
    private void h_RefreshButtonField()
    {
      foreach (Cell pCell in m_pField.CellList) {
        Button pB = h_FindButton(pCell.PositionX, pCell.PositionY);
        if (pB == null)
        {
          continue;
        }
        switch (pCell.Value) {
          case EValue.Empty:
            h_SetButton(pB);
            break;
          case EValue.X:
            h_SetButtonX(pB);
            break;
          case EValue.O:
            h_SetButton0(pB);
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

    }

    private Button h_FindButton(int iCellPositionX, int iCellPositionY)
    {
      foreach (Control pControl in panel1.Controls) {
        Tuple<int, int> pO = (pControl.Tag as Tuple<int, int>);
        if (pO == null) {
          continue;
        }
        int iX = pO.Item1;
        int iY = pO.Item2;
        if (iX == iCellPositionX && iY == iCellPositionY) {
          return pControl as Button;
        }

      }

      return null;
    }
    
    private void h_FillForm()
    {
      listView1.Items.Clear();
      int ii = 0;
      foreach (Mailbox pMb in m_pMailServer.MailboxList) {
        ListViewItem pLvi = listView1.Items.Add((++ii).ToString());
        pLvi.SubItems.Add(pMb.Address);
        pLvi.SubItems.Add($"{pMb.GetUnreadCount()} / {pMb.LetterList.Count}");
        pLvi.Tag = pMb;
      }
    }
    
    private void h_CreateButtonField()
    {
      this.panel1.SuspendLayout();
      foreach (Cell pCell in m_pField.CellList) {
        h_CreateButton(pCell.PositionX, pCell.PositionY);
      }
      h_RefreshButtonField();
      this.panel1.ResumeLayout();
    }

    private void h_CreateButton(int xx, int yy)
    {
      // создали кнопку
      Button thisbut0 = new System.Windows.Forms.Button();
      // 343-184-125=34
      int iPadding = 34;
      int iPaddingLeft = 25;
      int iButtonWidth = 135;
      int iPaddingTop = 35;
      int iButtonHeight = 125;
      // вычислили координату
      int xPos = iPaddingLeft + xx * (iButtonWidth + iPadding);
      int yPos = iPaddingTop + yy * (iButtonHeight + iPadding);
      thisbut0.Location = new System.Drawing.Point(xPos, yPos);
      // пометили кнопку, чтобы понять, какая она
      thisbut0.Tag = new Tuple<int, int>(xx, yy);
      // настройка кнопки
      thisbut0.UseVisualStyleBackColor = false;
      thisbut0.Size = new System.Drawing.Size(136, 125);
      thisbut0.Click += new System.EventHandler(this.but0_Click);
      this.panel1.Controls.Add(thisbut0);
    }

    private void h_SetButton(Button thisbut0)
    {
      thisbut0.BackColor = System.Drawing.Color.NavajoWhite;
      thisbut0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      thisbut0.Text = "";
    }
    
    private void h_SetButton0(Button thisbut0)
    {
      thisbut0.BackColor = System.Drawing.Color.White;
      thisbut0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      thisbut0.Text = "0";
    }

    private void h_SetButtonX(Button thisbutX)
    {
      thisbutX.BackColor = System.Drawing.Color.DarkGray;
      thisbutX.Font = new System.Drawing.Font("Tempus Sans ITC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      thisbutX.Text = "X";
    }

    #endregion

    private void but0_Click(object sender, System.EventArgs e)
    {
      Tuple<int, int> pO = ((sender as Control).Tag as Tuple<int, int>);
      int iX = pO.Item1;
      int iY = pO.Item2;

      m_pField.SetValue(iX, iY, EValue.X);

      h_RefreshButtonField();

      // MessageBox.Show($"{iX}/{iY} was clicked!");
    }
  }
}
