using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace L1.WcfServiceLibrary
{
  public class EncyclopediaService : IEncyclopediaService
  {
  
    /// <summary>
    /// Получение списка категорий и информации о энциклопедии
    /// </summary>
    /// <returns></returns>
    public EncyclopediaType GetInfo()
    {
      // TODO
      return null;
    }

    /// <summary>
    /// Получить информацию по разделу энциклопедии
    /// </summary>
    /// <param name="sCode"></param>
    /// <returns></returns>
    public EncyclopediaPartType GetPart(string sCode)
    {
      // TODO
      return null;
    }

    /// <summary>
    /// Получить полную словарную статью
    /// </summary>
    /// <param name="sCode"></param>
    /// <returns></returns>
    public EncyclopediaArticleType GetArticle(string sCode)
    {
      // TODO
      return null;
    }
  }
}
