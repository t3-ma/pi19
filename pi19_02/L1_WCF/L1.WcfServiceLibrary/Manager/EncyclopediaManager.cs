using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace L1.WcfServiceLibrary.Manager
{
  /// <summary>
  /// Менеджер энциклопедий
  /// </summary>
  public class EncyclopediaManager
  {
    /// <summary>
    /// Файл в каждой папке раздела с краткой информацией по статьям в разделе
    /// </summary>
    private const string RootFilename = "info.json";

    /// <summary>
    /// Файл с описанием внутренностей энциклопедии
    /// </summary>
    private const string RootFilenameEncyclopedia = "storage.json";

    /// <summary>
    /// Десериализация энциклопедии + разделы + краткая
    /// </summary>
    /// <param name="sDirectory"></param>
    /// <returns></returns>
    public EncyclopediaType Load(string sFullDirectory)
    {
      //EncyclopediaType pEncyclopedia =
      //  new EncyclopediaType();
      //pEncyclopedia.Title = "Пословицы и поговорки";
      //EncyclopediaPartType pPart1 =
      //  new EncyclopediaPartType();
      //pPart1.ArticleInfoList = new EncyclopediaArticleInfoType[] { };
      //pEncyclopedia.PartList = new[] { pPart1 };
      JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings()
      {
        Formatting = Formatting.Indented
      });
      using (FileStream pF = File.Open(Path.Combine(sFullDirectory, RootFilenameEncyclopedia), FileMode.Open))
      {
        using (TextReader pT = new StreamReader(pF))
        {
          EncyclopediaType pEncyclopedia = pSerializer.Deserialize(pT, typeof(EncyclopediaType)) as EncyclopediaType;
          return pEncyclopedia;
        }
      }
    }

    /// <summary>
    /// Десериализация энциклопедии + разделы + краткая
    /// </summary>
    /// <param name="sDirectory"></param>
    /// <returns></returns>
    public EncyclopediaPartType Load(string sFullDirectory, string sDirectory)
    {
      JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings()
      {
        Formatting = Formatting.Indented
      });
      using (FileStream pF = File.Open(Path.Combine(sFullDirectory, sDirectory, RootFilename), FileMode.Open))
      {
        using (TextReader pT = new StreamReader(pF))
        {
          EncyclopediaPartType encyclopediaPartType = pSerializer.Deserialize(pT, typeof(EncyclopediaPartType)) as EncyclopediaPartType;
          return encyclopediaPartType;
        }
      }
    }

    /// <summary>
    /// Десериализация статьи
    /// </summary>
    /// <param name="sDirectory"></param>
    /// <returns></returns>
    public EncyclopediaArticleType Load(string sFullDirectory, string sDirectory, string fileName)
    {
      JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings()
      {
        Formatting = Formatting.Indented
      });
      using (FileStream pF = File.Open(Path.Combine(sFullDirectory, sDirectory, fileName + ".json"), FileMode.Open))
      {
        using (TextReader pT = new StreamReader(pF))
        {
          EncyclopediaArticleType pEncyclopediaArticlePart = pSerializer.Deserialize(pT, typeof(EncyclopediaArticleType)) as EncyclopediaArticleType;
          return pEncyclopediaArticlePart;
        }
      }
    }

    /// <summary>
    /// Сохранить энциклопедию
    /// </summary>
    /// <param name="sDirectory"></param>
    /// <param name="pEncyclopedia"></param>
    public void Save(string sDirectory, EncyclopediaType pEncyclopedia)
    {
      Save<EncyclopediaType>(sDirectory, RootFilenameEncyclopedia, pEncyclopedia);
    }

    /// <summary>
    /// Сохранить краткую статью
    /// </summary>
    /// <param name="sDirectory"></param>
    /// <param name="pPart"></param>
    public void Save(string sDirectory, EncyclopediaPartType pPart)
    {
      string sDir = Path.Combine(sDirectory, pPart.Folder);
      Directory.CreateDirectory(sDir);
      Save<EncyclopediaPartType>(sDir, RootFilename, pPart);
    }

    /// <summary>
    /// Сохранить статью
    /// </summary>
    /// <param name="sDirectory"></param>
    /// <param name="pPart"></param>
    public void Save(string sDirectory, EncyclopediaArticleType pPart)
    {
      Save<EncyclopediaArticleType>(sDirectory, pPart.NameFileWithArticle + ".json", pPart);
    }

    /// <summary>
    /// Сохранение картинки по указанному пути на ПК (сервер)
    /// </summary>
    /// <param name="sFullWatToPicture"></param>
    /// <param name="image"></param>
    public void Save(string sFullWayToPicture, Image image)
    {
      image.Save(sFullWayToPicture, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    /// <summary>
    /// Общее сохранение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sDirectory"></param>
    /// <param name="sFilename"></param>
    /// <param name="pEncyclopedia"></param>
    public void Save<T>(string sDirectory, string sFilename, T pEncyclopedia)
    {
      JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings()
      {
        Formatting = Formatting.Indented
      });
      using (FileStream pF = File.Create(Path.Combine(sDirectory, sFilename)))
      {
        using (TextWriter pT = new StreamWriter(pF))
        {
          pSerializer.Serialize(pT, pEncyclopedia);
        }
      }
    }
  }
}