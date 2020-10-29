using pi192_03DLL.Memo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi192_03CA
{
  class Program
  {
    static Field _field;
    static void Main(string[] args)
    {
      _field = new Field(3, 3);

      h_Start();
    }

    private static void h_Start()
    {
      while(true) {
        h_DrawField();
        Console.WriteLine("Enter command..");
        string sCmd = Console.ReadLine();
        if (String.IsNullOrEmpty(sCmd)) {
          break;
        }

        if (sCmd.Equals("s")) {
          _field.Save($"{DateTime.Now:yyyy.MM.dd}.txt");
          continue;
        }
        if (sCmd.Equals("l")) {
          _field.Load($"{DateTime.Now:yyyy.MM.dd}.txt");
          continue;
        }

        string[] ar = sCmd.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length != 2) {
          continue;
        }
        int iN1, iN2;
        if (!Int32.TryParse(ar[0], out iN1)) {
          continue;
        }
        if (!Int32.TryParse(ar[1], out iN2)) {
          continue;
        }

        _field.Click(new Coord(iN1, iN2));
      }
    }

    private static void h_DrawField()
    {
      Console.Clear();
      ConsoleColor pCurrentColor = Console.ForegroundColor;
      foreach(Card pCard in _field.CardList) {
        if (pCard.IsFound) {
          Console.ForegroundColor = ConsoleColor.Black;
        }
        else {
          Console.ForegroundColor = pCard.IsOpened ? ConsoleColor.White : ConsoleColor.DarkGray;
        }
        Console.WriteLine(pCard);
      }
      Console.ForegroundColor = pCurrentColor;
    }
  }
}
