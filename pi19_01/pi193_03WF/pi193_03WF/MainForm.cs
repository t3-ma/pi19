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

namespace pi193_03WF
{
  public partial class MainForm : Form
  {
    private readonly CTestStaffDb _pDb;

    public MainForm(CTestStaffDb pDb)
    {
      _pDb = pDb;
      InitializeComponent();

      h_ShowInfo();

    }

    private void h_ShowInfo()
    {
      listView1.Items.Clear();
      foreach (CStaff pS in _pDb.StaffList)
      {
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
  }
}
