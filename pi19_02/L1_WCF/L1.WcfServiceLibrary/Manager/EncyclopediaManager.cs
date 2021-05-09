using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace L1.WcfServiceLibrary.Manager
{
  /// <summary>
  /// менеджер энциклопедий
  /// </summary>
  public class EncyclopediaManager
  {
    private const string RootFilename = "info.json";
    public EncyclopediaType Load(string sDirectory)
    {
      if (sDirectory == "")
      {
        EncyclopediaType pEncyclopedia = new EncyclopediaType();
        pEncyclopedia.Title = "Пословицы и поговорки";
        EncyclopediaPartType pPart1 = new EncyclopediaPartType();
        pPart1.Title = "123";
        pPart1.ArticleInfoList = new EncyclopediaArticleInfoType[] { };

        EncyclopediaPartType pPart2 = new EncyclopediaPartType();
        pPart2.Title = "456";
        pPart2.ArticleInfoList = new EncyclopediaArticleInfoType[] { };

        EncyclopediaPartType pPart3 = new EncyclopediaPartType();
        pPart3.Title = "789";
        pPart3.ArticleInfoList = new EncyclopediaArticleInfoType[] { };

        pEncyclopedia.PartList = new[] { pPart1, pPart2, pPart3};
      }

      JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings() {
        Formatting = Formatting.Indented
      });
      using (FileStream pF = File.Open(Path.Combine(sDirectory, RootFilename), FileMode.Open)) {
        using (TextReader pT = new StreamReader(pF)) {
          EncyclopediaType pEncyclopedia = pSerializer.Deserialize(pT, typeof(EncyclopediaType)) as EncyclopediaType;
          return pEncyclopedia;
        }
      }
    }

    public void Save(string sDirectory, EncyclopediaType pEncyclopedia)
    {
      Save<EncyclopediaType>(sDirectory, RootFilename, pEncyclopedia);
    }
    public void Save(string sDirectory, EncyclopediaPartType pPart)
    {
      string sDir = Path.Combine(sDirectory, pPart.Folder);
      Directory.CreateDirectory(sDir);
      Save<EncyclopediaPartType>(sDir, "/index.json", pPart);
    }

    public void Save<T>(string sDirectory, string sFilename, T pEncyclopedia)
    {
      JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings() {
        Formatting = Formatting.Indented
      });
      using (FileStream pF = File.Create(Path.Combine(sDirectory, sFilename))) {
        using (TextWriter pT = new StreamWriter(pF)) {
          pSerializer.Serialize(pT, pEncyclopedia);
        }
      }
    }
  }
}
