using System;

namespace pi192_03DLL.Memo
{
  public class Card
  {
    #region constructor
    protected Card()
    {
      Location = new Coord(0, 0);
    }

    public Card(int iX, int iY, string symbol)
    {
      Symbol = symbol;
      Location = new Coord(iX, iY);
      IsOpened = false; //default(bool) равно false;
    }
    public Card(string sCardString)
    {
      h_Parse(sCardString);
    }
    #endregion

    #region public properties
    /// <summary>
    /// Свойство: позиция карточки
    /// </summary>
    public Coord Location { get; set; }
    /// <summary>
    /// Свойство: символ, нанесенный на карточку
    /// </summary>
    public string Symbol { get; set; }
    /// <summary>
    /// Свойство: Открыта ли карточка игроком
    /// </summary>
    public bool IsOpened { get; set; }
    /// <summary>
    /// Свойство: Отгадана ли карточка игроком
    /// </summary>
    public bool IsFound { get; set; }

    /// <summary>
    /// Равна ли карточка спрашиваемой
    /// </summary>
    /// <param name="pCard"></param>
    /// <returns></returns>
    internal bool IsEqual(Card pCard)
    {
      return Symbol == pCard.Symbol;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{Location}: {(IsOpened ? Symbol : "-")}";
    }

    internal string AsStringForFile()
    {
      return $"{Location};{Symbol};{(IsOpened ? "1" : "0")};{(IsFound ? "1" : "0")}";
    }

    private void h_Parse(string sCardString)
    {
      string[] ar = sCardString.Split(new []{ ';' }, StringSplitOptions.None);
      if (ar.Length != 4) {
        return;
      }
      Location = new Coord(ar[0]);
      Symbol = ar[1];
      IsOpened = Int32.Parse(ar[2]) == 1;
      IsFound = Int32.Parse(ar[3]) == 1;
    }


  }
}
