using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pi193_03CL;
using pi193_03CL.ChessBoard;
using pi193_03CL.ModelCard;

namespace pi193_03WF
{
  public partial class MainForm : Form
  {
    private readonly CTestStaffDb _pDb;
    private readonly ChessBoard _chb;
    private readonly CGame _game;

    public MainForm(CTestStaffDb pDb)
    {
      _pDb = pDb;
      _chb = new ChessBoard(4,4);
      _game = new CGame(new[] {"player1", "player2"});

      InitializeComponent();

      h_ShowInfo();

      // h_FillField();
      h_ShowField();
      h_RefreshField();
    }

    private void h_RefreshField()
    {
      for (int iX = 0; iX < _chb.Width; iX++) {
        for (int iY = 0; iY < _chb.Height; iY++) {
          ChessCell pCell = _chb.GetCell(iX, iY);
          switch (pCell.Color) {
            case EColor.Black:
              h_SetButtonBlack(iX, iY);
              break;
            case EColor.White:
              h_SetButtonWhite(iX, iY);
              break;
          }
        }
      }
    }

    private void h_ShowField()
    {
      for (int iX = 0; iX < _chb.Width; iX++) {
        for (int iY = 0; iY < _chb.Height; iY++) {
          h_CreateButton(iX, iY);
        }
      }
      h_RefreshField();
    }

    private void h_FillField()
    {
      for (int iX = 0; iX < 8; iX++) {
        for (int iY = 0; iY < 8; iY++) {
          h_CreateButton(iX, iY);
          if (iX % 2 == 0 && iY % 2 == 0) {
            h_SetButtonBlack(iX, iY);
          }
          else {
            h_SetButtonWhite(iX, iY);
          }
        }
      }
    }

    private void h_SetButtonWhite(int iX, int iY)
    {
      Button btnBlack = h_GetButton(iX, iY);
      btnBlack.BackColor = System.Drawing.Color.White;
    }

    private Button h_GetButton(int iX, int iY)
    {
      // if (this.Controls.Count == 1) 
      foreach(Control pControl in tabPage2.Controls) {
        if (!(pControl is Button)) {
          continue;
        }
        Position p = pControl.Tag as Position;
        if (p == null) {
          continue;
        }

        if(p.X == iX && p.Y == iY) {
          return pControl as Button;
        }
      }
      return null;
    }

    private void h_SetButtonBlack(int iX, int iY)
    {
      Button btnBlack = h_GetButton(iX, iY);
      btnBlack.BackColor = System.Drawing.Color.Black;
    }

    private void h_CreateButton(int iX, int iY)
    {
      int iWidth = 46;
      int iHeight = 46;
      int iPaddingLeft = 32;
      int iPadding = 6;
      int iPaddingTop = 22;

      Button btnBlack = new Button();
      btnBlack.BackColor = System.Drawing.Color.Black;

      int iPosX = iPaddingLeft + iX * (iWidth + iPadding);
      int iPosY = iPaddingTop + iY * (iHeight + iPadding);

      btnBlack.Location = new System.Drawing.Point(iPosX, iPosY);
      btnBlack.Size = new System.Drawing.Size(46, 46);
      btnBlack.UseVisualStyleBackColor = false;

      btnBlack.Tag = new Position(iX, iY);
      btnBlack.Click += new System.EventHandler(this.button1_Click);

      tabPage2.Controls.Add(btnBlack);
    }

    private void h_ShowInfo()
    {
      listView1.Items.Clear();
      foreach (CStaff pS in _pDb.StaffList) {
        ListViewItem pItem = listView1.Items.Add(pS.Fio);
        pItem.SubItems.Add(pS.RankTitle);
        pItem.SubItems.Add(pS.BirthDate.ToString());
        pItem.Tag = pS;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      MessageBox.Show(_pDb.StaffList.Count.ToString());
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Button pB = (sender as Button);
      if (pB == null) {
        return;
      }
      Position pPos = pB.Tag as Position;
      if (pPos == null) {
        return;
      }
      _chb.Click(pPos.X, pPos.Y);

      // h_RefreshField();
      //MessageBox.Show($"{pPos.X} / {pPos.Y}");
    }

    private void formTimer_Tick(object sender, EventArgs e)
    {
      // formTimer.Enabled = true;
      h_RefreshField();


      h_RefreshCardField();

    }

    private void h_RefreshCardField()
    {
      switch (_game.State) {
        case EGameState.NewGame:
        case EGameState.GameOver:
          panGame.Visible = false;
          panNewGame.Visible = true;
          break;
        default:
          panGame.Visible = true;
          panNewGame.Visible = false;
          h_FillCardField();
          break;
      }
    }

    private void h_FillCardField()
    {
      // 
    }

    
    private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _game.NewGame();
    }
  }
}
