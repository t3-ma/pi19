using pi191_03CL.Model;
using System.Windows.Forms;

namespace pi191_03WF
{
  public partial class MainForm : Form
  {
    #region private variables
    private readonly TestMailServer m_pMailServer;
    #endregion

    #region constructor
    public MainForm(TestMailServer pMailServer)
    {
      m_pMailServer = pMailServer;
      InitializeComponent();
      h_FillForm();
    }
    #endregion


    #region private methods
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
    #endregion

  }
}
