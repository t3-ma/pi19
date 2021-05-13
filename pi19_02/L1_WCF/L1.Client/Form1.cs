using L1.WcfServiceLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    private static System.Timers.Timer aTimer;
    EncyclopediaServiceClient client;
    private int k = 0;

    //ServiceReference2.Service1Client client;
    public Form1()
    {
      InitializeComponent();
      //string sUrlService = "http://127.0.0.1:8000/EncyclopediaService";
      //BasicHttpContextBinding pBinding = new BasicHttpContextBinding();
      //EndpointAddress pEndpointAddress = new EndpointAddress(sUrlService);
      //client = new EncyclopediaServiceClient(pBinding, pEndpointAddress);
      txtAddr.Text = "http://127.0.0.1:8000/EncyclopediaService";
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      BasicHttpBinding pBinding = new BasicHttpBinding();
      pBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
      pBinding.Security.Mode = BasicHttpSecurityMode.None;

      EncyclopediaServiceClient pClient =
        new EncyclopediaServiceClient(
          pBinding,
          new EndpointAddress(txtAddr.Text));
      MessageBox.Show(pClient.GetStatus().ToString());
      //EncyclopediaType pEncyclopediaType = pClient.GetInfo();

      //Text = pEncyclopediaType.Title;
      //h_RefreshParts(pEncyclopediaType.PartList);

    }

    private void h_RefreshParts(EncyclopediaPartType[] partList)
    {
      lvParts.Items.Clear();
      foreach (EncyclopediaPartType pItem in partList)
      {
        ListViewItem pLvItem = lvParts.Items.Add(pItem.Title);
        pLvItem.SubItems.Add(pItem.ArticleInfoList.Length.ToString());
        pLvItem.Tag = pItem;
      }
    }

    private void lvParts_SelectedIndexChanged(object sender, EventArgs e)
    {

      if (lvParts.SelectedItems.Count == 0 ||
          lvParts.SelectedItems[0].Tag == null)
      {
        lvArticles.Visible = false;
        return;
      }
      lvArticles.Visible = true;

      h_RefreshArticles(lvParts.SelectedItems[0].Tag as EncyclopediaPartType);

    }

    private void h_RefreshArticles(EncyclopediaPartType encyclopediaPartType)
    {
      //      lvArticles.Items.Add(encyclopediaPartType.ArticleInfoList[0])
      // ...TODO...
    }

    private void lvArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
      // ...TODO...
    }
    private void SetTimer()
    {
      aTimer = new System.Timers.Timer(300);
      aTimer.Elapsed += OnTimedEvent;
      aTimer.AutoReset = true;
      aTimer.Enabled = true;

      //BackgroundWorker worker = new BackgroundWorker();
      //worker.DoWork += worker_DoWork;
      //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
      //worker.RunWorkerAsync(1000);
    }

    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        if (client.GetStatus())
        {
          e.Result = true;
        };
      }
      catch (Exception)
      {
        e.Result = false;
      }
    }

    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if ((bool)e.Result)
      {
        this.BackColor = Color.Green;
        //label2.Text = $"Состояние сервера: работает ({k})";
      }
      else
      {
        this.BackColor = Color.Red;
        //label2.Text = $"Состояние сервера: не работает ({k})";
      }
      k++;
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      try
      {
        if (client.GetStatus())
        {
          this.BackColor = Color.Green;
        };
      }
      catch (Exception)
      {
        this.BackColor = Color.Red;
        throw;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      SetTimer();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      MessageBox.Show(client.GetInfo().ToString());
    }
  }
}
