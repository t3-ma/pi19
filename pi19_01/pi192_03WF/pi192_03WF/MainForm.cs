using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using pi192_03DLL.Memo;
using pi192_03DLL.Model;

namespace pi192_03WF
{
  public partial class MainForm : Form
  {
    private readonly BookCollection _pBookCollection;
    private readonly Field _field;

    public MainForm(BookCollection pBookCollection)
    {
      _pBookCollection = pBookCollection;
      _field = new Field(4, 4);
      InitializeComponent();
      h_ShowBooks();
      h_FillField();
    }
    private void h_FillFieldOld()
    {
      int Width = 4; int Height = 4;
      for (int iX = 0; iX < Width; iX++) {
        for (int iY = 0; iY < Height; iY++) {
          h_CreateCard(iX, iY);
        }
      }
    }


    private void h_FillField()
    {
      for (int iX = 0; iX < _field.Width; iX++) {
        for (int iY = 0; iY < _field.Height; iY++) {
          h_CreateCard(iX, iY);
          h_RefreshCard(iX, iY);
        }
      }
    }

    private void h_RefreshField()
    {
      for (int iX = 0; iX < _field.Width; iX++) {
        for (int iY = 0; iY < _field.Height; iY++) {
          h_RefreshCard(iX, iY);
        }
      }
    }

    private void h_RefreshCard(int iX, int iY)
    {
      Card pCard = _field.GetCard(iX, iY);
      Button pButton = h_GetButton(iX, iY);
      if (pCard == null || pButton == null) {
        return;
      }
      if (pCard.IsFound) {
        pButton.Visible = false;
      }
      else {
        pButton.Visible = true;
        pButton.Text = pCard.IsOpened ? pCard.Symbol : String.Empty;
        pButton.BackColor = pCard.IsOpened ? Color.White : Color.Gray;
      }
    }

    private Button h_GetButton(int iX, int iY)
    {
      foreach(Control pC in tabPage2.Controls) {
        Button pB = (pC as Button);
        if (pB == null) {
          continue;
        }
        Coord pCoord = pB.Tag as Coord;
        if (pCoord == null) {
          continue;
        }
        if (pCoord.X == iX && pCoord.Y == iY) {
          return pB;
        }
      }
      return null;
    }

    private void h_CreateCard(int iX, int iY)
    {
      const int Width = 91;
      const int Height = 91;
      const int Padding = 6;
      const int PaddingLeft = 17;
      const int PaddingTop = 20;

      int iPosX = PaddingLeft + (Width + Padding) * iX;
      int iPosY = PaddingTop + (Height + Padding) * iY;

      Button btnTest = new Button();
      this.tabPage2.Controls.Add(btnTest);
      btnTest.Location = new System.Drawing.Point(iPosX, iPosY);
      btnTest.Size = new System.Drawing.Size(Width, Height);
      btnTest.UseVisualStyleBackColor = true;
      btnTest.Click += new System.EventHandler(this.btnTest_Click);
      btnTest.Tag = new Coord(iX, iY);
    }

    private void h_ShowBooks()
    {
      int ii = 0;
      listView1.Items.Clear();
      foreach (Book pBook in _pBookCollection.BookList) {
        ListViewItem pItem = listView1.Items.Add((++ii).ToString());
        pItem.SubItems.Add(pBook.Author);
        pItem.SubItems.Add(pBook.Title);
        pItem.Tag = pBook;
      }
      // ....
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      Button pB = (sender as Button);
      if (pB == null) {
        return;
      }
      Coord pC = pB.Tag as Coord;
      if (pC == null) {
        return;
      }

      _field.Click(pC);
      h_RefreshField();
      // MessageBox.Show($"{pC.X} / {pC.Y}");
    }
  }
}
