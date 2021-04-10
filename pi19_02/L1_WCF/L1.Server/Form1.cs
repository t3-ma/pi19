using L1.WcfServiceLibrary;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace L1.Server
{
  public partial class Form1 : Form
  {
    private ServiceHost m_pHost;
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string sUrlService = "http://127.0.0.1:8000/EncyclopediaService";
      string sUrlServiceMeta = "http://127.0.0.1:8000/EncyclopediaService/Meta";
      // Привязка для основного сервиса
      BasicHttpBinding pBinding = new BasicHttpBinding();
      pBinding.Security.Transport.ClientCredentialType =
     HttpClientCredentialType.None;
      pBinding.Security.Mode = BasicHttpSecurityMode.None;
      // Поведение для публикации информации о сервисе
      ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
      smb.HttpGetEnabled = true;
      smb.HttpGetUrl = new Uri(sUrlServiceMeta);
      smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
      // Создаем хост
      m_pHost = new ServiceHost(typeof(EncyclopediaService));
      m_pHost.Description.Behaviors.Add(smb);
      // Добавляем обслуживание основного функционала
      m_pHost.AddServiceEndpoint(typeof(IEncyclopediaService), pBinding, sUrlService);
      // Добавляем обслуживание публикации информации о сервисе
      m_pHost.AddServiceEndpoint(typeof(IMetadataExchange),
     MetadataExchangeBindings.CreateMexHttpBinding(), sUrlServiceMeta);
      m_pHost.Open();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      m_pHost.Close();
    }
  }
}
