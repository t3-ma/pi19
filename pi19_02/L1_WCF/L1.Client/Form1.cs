using L1.WcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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
      string sUrlService = "http://127.0.0.1:8000/EncyclopediaService";
      BasicHttpContextBinding pBinding = new BasicHttpContextBinding();
      EndpointAddress pEndpointAddress = new EndpointAddress(sUrlService);
      client = new EncyclopediaServiceClient(pBinding, pEndpointAddress);
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
        label2.Text = $"Состояние сервера: работает ({k})";
      }
      else
      {
        this.BackColor = Color.Red;
        label2.Text = $"Состояние сервера: не работает ({k})";
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
