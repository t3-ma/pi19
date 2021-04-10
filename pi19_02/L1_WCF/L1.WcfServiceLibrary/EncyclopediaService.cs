﻿using L1.WcfServiceLibrary.Manager;

namespace L1.WcfServiceLibrary
{
  public class EncyclopediaService : IEncyclopediaService
  {

    /// <summary>
    /// Статус
    /// </summary>
    /// <returns></returns>
    public bool GetStatus()
    {
      return true;
    }

    /// <summary>
    /// Получение списка категорий и информации о энциклопедии
    /// </summary>
    /// <returns></returns>
    public EncyclopediaType GetInfo()
    {
      EncyclopediaManager pManager = new EncyclopediaManager();
      EncyclopediaType pEncyclopedia = pManager.Load("");
      return pEncyclopedia;
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
    public EncyclopediaArticleType GetArticle(string sPart, string sCode)
    {
      // TODO
      return null;
    }
  }
}
