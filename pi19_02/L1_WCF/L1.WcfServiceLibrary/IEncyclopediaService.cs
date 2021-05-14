using System;
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

    /// <summary>
    /// Картинки
    /// </summary>
    /// <param name="sDirectoryCode"></param>
    /// <param name="sFileNameCode"></param>
    /// <returns></returns>
    [OperationContract]
    byte[] GetImages(string sDirectoryCode, string sImgNameCode);
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

    /// <summary>
    /// Автор
    /// </summary>
    [DataMember]
    public string Author { get; set; }

    /// <summary>
    /// Имя папки
    /// </summary>
    [DataMember]
    public string Folder { get; set; }
  }

  /// <summary>
  /// Раздел энциклопедии
  /// </summary>
  [DataContract]
  public class EncyclopediaPartType
  {
    /// <summary>
    /// Список всех кратких информаций энциклопедии внутри файла info.json
    /// </summary>
    [DataMember]
    public EncyclopediaArticleInfoType[] ArticleInfoList { get; set; }

    /// <summary>
    /// Имя папки
    /// </summary>
    [DataMember]
    public string Folder { get; set; } //001

    /// <summary>
    /// Название раздела
    /// </summary>
    [DataMember]
    public string NameEncyclopediaPartType { get; set; }

  }

  /// <summary>
  /// Краткая информация о статье энциклопедии
  /// </summary>
  [DataContract]
  public class EncyclopediaArticleInfoType
  {
    /// <summary>
    /// Название статьи
    /// </summary>
    [DataMember]
    public string NameShortArticle { get; set; }

    /// <summary>
    /// Названия файла с полной статьей для дальнейшего поиска
    /// </summary>
    [DataMember]
    public string NameFileFullArticle { get; set; }

    /// <summary>
    /// Краткое описание статьи
    /// </summary>
    [DataMember]
    public string Notes { get; set; }

  }

  /// <summary>
  /// Полная статья энциклопедии с иллюстрацией
  /// </summary>
  [DataContract]
  public class EncyclopediaArticleType
  {
    /// <summary>
    /// Название файла, содержащего статью
    /// </summary>
    [DataMember]
    public string NameFileWithArticle { get; set; }

    /// <summary>
    /// Название статьи
    /// </summary>
    [DataMember]
    public string NameArticle { get; set; }


    /// <summary>
    /// Сам текст статьи
    /// </summary>
    [DataMember]
    public string MainArticleText { get; set; }
  }
}
