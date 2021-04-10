﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace L1.WcfServiceLibrary
{
  /// <summary>
  /// Сервис "Электронная энциклопедия"
  /// </summary>
  [ServiceContract]
  public interface IEncyclopediaService
  {
    /// <summary>
    /// Статус
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    bool GetStatus();

    /// <summary>
    /// Получение списка категорий и информации о энциклопедии
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    EncyclopediaType GetInfo();

    /// <summary>
    /// Получить информацию по разделу энциклопедии
    /// </summary>
    /// <param name="sCode"></param>
    /// <returns></returns>
    [OperationContract]
    EncyclopediaPartType GetPart(string sCode);

    /// <summary>
    /// Получить полную словарную статью
    /// </summary>
    /// <param name="sPart"></param>
    /// <param name="sCode"></param>
    /// <returns></returns>
    [OperationContract]
    EncyclopediaArticleType GetArticle(string sPart, string sCode);
  }

  /// <summary>
  /// Энциклопедия
  /// </summary>
  [DataContract]
  public class EncyclopediaType
  {
    /// <summary>
    /// Название энциклопедии
    /// </summary>
    [DataMember]
    public string Title { get; set; }

    /// <summary>
    /// Список разделов энциклопедии
    /// </summary>
    [DataMember]
    public EncyclopediaPartType[] PartList { get; set; }

    // TODO
  }

  /// <summary>
  /// Раздел энциклопедии
  /// </summary>
  [DataContract]
  public class EncyclopediaPartType
  {
    /// <summary>
    /// Список разделов энциклопедии
    /// </summary>
    [DataMember]
    public EncyclopediaArticleInfoType[] ArticleInfoList { get; set; }

    /// <summary>
    /// Имя папки
    /// </summary>
    [DataMember]
    public string Folder { get; set; }
    // TODO
  }

  /// <summary>
  /// Краткая информация о статье энциклопедии
  /// </summary>
  [DataContract]
  public class EncyclopediaArticleInfoType
  {
    // TODO
  }

  /// <summary>
  /// Полная статья энциклопедии с иллюстрацией
  /// </summary>
  [DataContract]
  public class EncyclopediaArticleType
  {
    // TODO
  }
}
