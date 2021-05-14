using L1.WcfServiceLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
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

    private void Clear()
    {
      textBox1.Text = "";
      richTextBox1.Text = "";
      pictureBox1.Image = null;
    }

    private void OpenEdit()
    {
      textBox1.ReadOnly = false;
      richTextBox1.ReadOnly = false;
    }

    private void CloseEdit()
    {
      textBox1.ReadOnly = true;
      richTextBox1.ReadOnly = true;
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      try
      {
        BasicHttpBinding pBinding = new BasicHttpBinding();
        pBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
        pBinding.Security.Mode = BasicHttpSecurityMode.None;

        pBinding.MaxReceivedMessageSize = int.MaxValue;
        pBinding.Name = "BasicHttpBinding_IEncyclopediaService";
        pBinding.ReaderQuotas = XmlDictionaryReaderQuotas.Max;

        client =
          new EncyclopediaServiceClient(
            pBinding,
            new EndpointAddress(txtAddr.Text));
        EncyclopediaType encyclopediaType = client.GetInfo();
        MessageBox.Show("Добро пожаловать в электронную энциклопедию \"" + encyclopediaType.Title + "\"\n" +
            "Автор: " + encyclopediaType.Author);

        dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        dataGridView1.DataSource = encyclopediaType.PartList;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridView1.Columns[1].HeaderText = "Раздел";
        //скрываем папку для дальнейшней передачи
        dataGridView1.Columns[0].Visible = false;

        Clear();
        CloseEdit();
      }
      catch
      {
        MessageBox.Show("Нет ответа от сервера.", "ERROR", MessageBoxButtons.OK);
      }
    }

    private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
      {
        EncyclopediaPartType encyclopediaPartType = client.GetPart(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

        dataGridView2.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        dataGridView2.DataSource = encyclopediaPartType.ArticleInfoList;

        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        dataGridView2.Columns["NameFileFullArticle"].DisplayIndex = 0;
        dataGridView2.Columns["NameShortArticle"].DisplayIndex = 1;
        dataGridView2.Columns["Notes"].DisplayIndex = 2;

        dataGridView2.Columns["NameFileFullArticle"].Visible = false;
        dataGridView2.Columns["NameShortArticle"].HeaderText = "Название статьи";
        dataGridView2.Columns["Notes"].HeaderText = "Описание";

        Clear();
        CloseEdit();
      }
      catch
      {
        MessageBox.Show("Нет ответа от сервера.", "ERROR", MessageBoxButtons.OK);
      }
    }

    private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
      {
        EncyclopediaArticleType encyclopediaArticleType = client.GetArticle(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(),
        dataGridView2["NameFileFullArticle", dataGridView2.CurrentRow.Index].Value.ToString());

        //вывод информации об энциклопедии
        textBox1.Text = encyclopediaArticleType.NameArticle;
        richTextBox1.Text = encyclopediaArticleType.MainArticleText;

        MemoryStream ms = new MemoryStream(client.GetImages(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(),
                dataGridView2["NameFileFullArticle", dataGridView2.CurrentRow.Index].Value.ToString()));
        Image returnImage = Image.FromStream(ms);
        pictureBox1.Image = returnImage;
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        CloseEdit();

      }
      catch
      {
        MessageBox.Show("Нет ответа от сервера.", "ERROR", MessageBoxButtons.OK);
      }
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

    private void button3_Click(object sender, EventArgs e)
    {
      OpenEdit();
    }
  }
}
