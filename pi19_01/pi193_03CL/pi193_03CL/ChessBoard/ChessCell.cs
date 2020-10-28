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

  }
}