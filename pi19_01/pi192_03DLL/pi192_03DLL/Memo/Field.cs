using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace pi192_03DLL.Memo
{
  public class Field
  {
    private Timer m_pTimer;

    #region constructors
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="iWidth"></param>
    /// <param name="iHeight"></param>
    public Field(int iWidth, int iHeight) : this()
    {
      TimeSpan tsInterval = new TimeSpan(0,0,0,0,500);
      m_pTimer = new Timer(h_OnTimer, null, tsInterval, tsInterval);
      // m_pTimer.Change()
      Width = iWidth;
      Height = iHeight;
      h_Fill();
    }

    /// <summary>
    /// Конструктор по умолчанию (без параметров)
    /// </summary>
    protected Field()
    {
      CardList = new List<Card>();
    }

    #endregion

    private void h_OnTimer(object state)
    {
      OnTimer();
    }



    private void h_Fill()
    {
      // массив из строк для нанесения на карточки
      List<string> ar = new List<string>();
      for (int ii = 0; ii < (Width * Height / 2) + 1; ii++) {
        ar.Add(ii.ToString());
        ar.Add(ii.ToString());
      }
      Random pRand = new Random();

      // заполняем массив карточке
      for (int iX = 0; iX < Width; iX++) {
        for (int iY = 0; iY < Height; iY++) {
          // подбираем случайный индекс
          int iIndex = pRand.Next(0, ar.Count);
          string sR = ar[iIndex];
          // удаляем использованный элемент
          ar.RemoveAt(iIndex);
          // создаем карточку
          Card pCard = new Card(iX, iY, sR);
          CardList.Add(pCard);
        }
      }
    }
    private void h_CheckDouble()
    {
      Card pSelectedCard = null;
      foreach (Card pCard in CardList) {
        // если карта закрыта
        if (!pCard.IsOpened) {
          continue;
        }
        // если найденная карта - первая из
        if (pSelectedCard == null) {
          pSelectedCard = pCard;
          continue;
        }
        // если найденная карта второй
        // присваиваем время закрытия карт
        DateTime dtOver = DateTime.Now.AddSeconds(2);
        pCard.CloseTime = pSelectedCard.CloseTime = dtOver;
        // если карты равны
        if (pSelectedCard.IsEqual(pCard)) {
          pCard.IsFound = true;
          pSelectedCard.IsFound = true;
        }
        else {
          // pCard.IsOpened = false;
          // pSelectedCard.IsOpened = false;
        }
      }
    }

    public void OnTimer()
    {
      foreach (var pCard in CardList)
      {
        if (!pCard.CloseTime.HasValue)
        {
          continue;
        }

        if (DateTime.Now > pCard.CloseTime.Value)
        {
          pCard.CloseTime = null;
          pCard.IsOpened = false;
        }
      }
    }


    #region public properties
    /// <summary>
    /// Свойство: Список карт на столе
    /// </summary>
    // [XmlElement("iteM")]
    public List<Card> CardList { get; }
    /// <summary>
    /// Свойство: ширина поля (количество столбцов)
    /// </summary>
    [XmlAttribute]
    public int Width { get; set; }
    /// <summary>
    /// Свойство: высота поля (количество строк)
    /// </summary>
    [XmlAttribute("heighT")]
    public int Height { get; set; }
    #endregion

    [XmlIgnore]
    public string FileSignature = "memo.v1";


    /// <summary>
    /// Возвращает карту, которая находится в заданной строке и в заданном столбце (если нет - возвращает null)
    /// </summary>
    /// <param name="iX"></param>
    /// <param name="iY"></param>
    /// <returns></returns>
    public Card GetCard(int iX, int iY)
    {
      foreach (var pC in CardList) {
        if (pC.Location.X == iX && pC.Location.Y == iY) {
          return pC;
        }
      }
      return null;
    }

    /// <summary>
    /// Посылает команду полю, что пользователь выбрал карточку в заданной позиции
    /// </summary>
    /// <param name="pC"></param>
    public void Click(Coord pC)
    {
      Card pCard = GetCard(pC.X, pC.Y);
      if (pCard == null) {
        return;
      }
      pCard.IsOpened = !pCard.IsOpened;
      h_CheckDouble();
    }

    /// <summary>
    /// Загружает из файла
    /// </summary>
    /// <param name="sFileName"></param>
    public void Load(string sFileName)
    {
      if (!File.Exists(sFileName)) {
        return;
      }
      // считать файл в строку
      string[] arContent = File.ReadAllLines(sFileName);

      if (arContent.Length < 3) {
        return;
      }
      int iLineNum = 0;
      if (arContent[iLineNum++] != FileSignature) {
        return;
      }
      CardList.Clear();
      Width = Int32.Parse(arContent[iLineNum++]);
      Height = Int32.Parse(arContent[iLineNum++]);
      for (int ii = iLineNum; ii < arContent.Length; ii++) {
        Card pCard = new Card(arContent[ii]);
        CardList.Add(pCard);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sFileName"></param>
    public void Save(string sFileName)
    {
      StringBuilder pSb = new StringBuilder();
      pSb.AppendLine(FileSignature);
      pSb.AppendLine(Width.ToString());
      pSb.AppendLine(Height.ToString());
      foreach (var pC in CardList) {
        pSb.AppendLine(pC.AsStringForFile());
      }
      string sContent = pSb.ToString();
      // сохранить содержимое строки в файл
      File.WriteAllText(sFileName, sContent);
    }


  }
}
