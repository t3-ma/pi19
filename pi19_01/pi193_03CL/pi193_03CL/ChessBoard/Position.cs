using System;

namespace pi193_03CL.ChessBoard
{
  /// <summary>
  /// Позиция (координаты)
  /// </summary>
  public class Position
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="sPosition"></param>
    public Position(string sPosition)
    {
      string[] ar = sPosition.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
      X = Int32.Parse(ar[0]);
      Y = Int32.Parse(ar[1]);
    }

    public override string ToString()
    {
      return $"{X},{Y}";
    }

    /// <summary>
    /// Свойство: координата X
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Свойство: координата Y
    /// </summary>
    public int Y { get; set; }
  }
}
