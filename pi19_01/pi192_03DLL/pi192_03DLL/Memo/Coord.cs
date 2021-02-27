using System;
using System.Net.Http.Headers;

namespace pi192_03DLL.Memo
{
  public class Coord
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Coord(int x, int y)
    {
      X = x;
      Y = y;
    }
    public Coord(string sCoordAsString)
    {
      string[] ar = sCoordAsString.Split(new[] { ',' });
      if (ar.Length != 2) {
        return;
      }
      X = Int32.Parse(ar[0]);
      Y = Int32.Parse(ar[1]);
    }
    private Coord()
    {
    }

    /// <summary>
    /// Свойство: номер столбца
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Свойство: номер строки
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{X},{Y}";
    }

  }
}
