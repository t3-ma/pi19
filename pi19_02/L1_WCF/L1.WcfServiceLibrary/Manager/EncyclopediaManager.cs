using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.WcfServiceLibrary.Manager
{
  /// <summary>
  /// менеджер энциклопедий
  /// </summary>
  public class EncyclopediaManager
  {
    public EncyclopediaType Load(string sFilename)
    {
      EncyclopediaType pEncyclopedia =
        new EncyclopediaType();
      pEncyclopedia.Title = "Пословицы и поговорки";
      EncyclopediaPartType pPart1 =
        new EncyclopediaPartType();
      pPart1.ArticleInfoList = new EncyclopediaArticleInfoType[] { };
      pEncyclopedia.PartList = new[] { pPart1 };
      return pEncyclopedia;
    }
  }
}
