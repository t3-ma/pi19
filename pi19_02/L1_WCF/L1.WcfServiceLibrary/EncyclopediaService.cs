using L1.WcfServiceLibrary.Manager;
using System.Drawing;
using System.IO;

namespace L1.WcfServiceLibrary
{
  public class EncyclopediaService : IEncyclopediaService
  {
    private const string Folder = "C:/Users/t3ma/source/repos/pi19/pi19_02/L1_WCF/Bibl2test";

    public bool GetStatus()
    {
      return true;
    }

    public EncyclopediaType GetInfo()
    {
      EncyclopediaManager pManager = new EncyclopediaManager();
      EncyclopediaType pEncyclopedia = pManager.Load(Folder);
      return pEncyclopedia;
    }

    public EncyclopediaPartType GetPart(string sCode)
    {
      EncyclopediaManager pManager = new EncyclopediaManager();
      EncyclopediaPartType encyclopediaPartType = pManager.Load(Folder, sCode);
      return encyclopediaPartType;
    }

    public EncyclopediaArticleType GetArticle(string sPart, string sCode)
    {
      EncyclopediaManager pManager = new EncyclopediaManager();
      EncyclopediaArticleType encyclopediaArticleType = pManager.Load(Folder, sPart, sCode);
      return encyclopediaArticleType;
    }

    public void EditArticle(string sPart, string sCode, string sArticleName, string sArticleText)
    {
      EncyclopediaManager pManager = new EncyclopediaManager();

      EncyclopediaArticleType encyclopediaArticleType = pManager.Load(Folder, sPart, sCode);

      encyclopediaArticleType.MainArticleText = sArticleText;
      encyclopediaArticleType.NameArticle = sArticleName;

      pManager.Save(Path.Combine(Folder, sPart), encyclopediaArticleType);
    }

    public byte[] GetImages(string sPart, string sCode)
    {
      Image img = Image.FromFile(Path.Combine(Folder, sPart, sCode + ".jpg"));
      byte[] byteArray = new byte[1000000];
      using (MemoryStream stream = new MemoryStream())
      {
        img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        stream.Close();

        byteArray = stream.ToArray();
      }

      return byteArray;
    }
  }
}
