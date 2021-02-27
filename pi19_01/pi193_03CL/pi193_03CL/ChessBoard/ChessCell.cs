using System;

namespace pi193_03CL.ChessBoard
{
  /// <summary>
  /// Класс клетки шахматного поля
  /// </summary>
  public class ChessCell
  {

    /// <summary>
    /// Расположение клетки
    /// </summary>
    public Position Pos { get; }
    /// <summary>
    /// Свойства: Цвет клетки
    /// </summary>
    public EColor Color { get; set; }

    /// <summary>
    /// Свойство: время перевертывания обратно
    /// </summary>
    public DateTime? TimeToLive { get; set; }

    public override string ToString()
    {
      return $"{Pos.ToString()};{(int)Color}";
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="iX"></param>
    /// <param name="iY"></param>
    /// <param name="color"></param>
    public ChessCell(int iX, int iY, EColor color)
    {
      Pos = new Position(iX, iY);
      Color = color;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="sCell"></param>
    public ChessCell(string sCell)
    {
      string[] ar = sCell.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
      Pos = new Position(ar[0]);
      Color = (EColor)(Int32.Parse(ar[1]));
    }

    public void Click()
    {
      Color = Color == EColor.Black
        ? EColor.White
        : EColor.Black;
      if (Color == EColor.Black) {
        TimeToLive = DateTime.Now.AddSeconds(5);
      }
      else
      {
        TimeToLive = null;
      }
    }

    public bool CheckToBeReverted()
    {
      if (Color == EColor.White)
      {
        return false;
      }

      if (TimeToLive < DateTime.Now)
      {
        Color = EColor.White;
        TimeToLive = null;
        return true;
      }

      return false;
    }
  }
}