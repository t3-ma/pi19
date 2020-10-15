using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pi192_03DLL.Model;

namespace pi192_03WF
{
  public partial class MainForm : Form
  {
    private readonly BookCollection _pBookCollection;

    public MainForm(BookCollection pBookCollection)
    {
      _pBookCollection = pBookCollection;
      InitializeComponent();
      h_ShowBooks();
    }

    private void h_ShowBooks()
    {
      int ii = 0;
      listView1.Items.Clear();
      foreach (Book pBook in _pBookCollection.BookList)
      {
        ListViewItem pItem = listView1.Items.Add((++ii).ToString());
        pItem.SubItems.Add(pBook.Author);
        pItem.SubItems.Add(pBook.Title);
        pItem.Tag = pBook;
      }
      // ....
    }
  }
}
