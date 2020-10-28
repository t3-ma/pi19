using pi193_03CL.ChessBoard;
using System;
using System.Runtime.InteropServices;

namespace pi193_03CApp
{
  class Program
  {
    private static ChessBoard _pCb;

    static void Main(string[] args)
    {
      _pCb = new ChessBoard(4, 4);
      h_ProcessLoop();
      Console.ReadKey();
    }

    private static void h_ProcessLoop()
    {
      _pCb.Load($"{DateTime.Now.ToString("yyyy.MM.dd")}.txt");
      while (true) {
        h_RefreshField();
        Console.WriteLine("Enter cell position");
        string sLine = Console.ReadLine();
        if (sLine.Equals("s")) {
          _pCb.Save($"{DateTime.Now.ToString("yyyy.MM.dd")}.txt");
          continue;
        }
        if (sLine.Equals("l")) {
          _pCb.Load($"{DateTime.Now.ToString("yyyy.MM.dd")}.txt");
          continue;
        }
        string[] ar = sLine.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length == 0) {
          break;
        }
        if (ar.Length != 2) {
          continue;
        }
        int iN1;
        if (!Int32.TryParse(ar[0], out iN1)) {
          continue;
        }
        int iN2;
        if (!Int32.TryParse(ar[1], out iN2)) {
          continue;
        }
        _pCb.Click(iN1, iN2);
      }
    }

    private static void h_RefreshField()
    {
      Console.Clear();
      ConsoleColor pCC = Console.ForegroundColor;
      foreach (var pC in _pCb.CellList) {
        Console.ForegroundColor = (pC.Color == EColor.Black ? ConsoleColor.DarkGray : ConsoleColor.White);
        Console.WriteLine($"{pC.Pos.X},{pC.Pos.Y}: {pC.Color}");
      }
      Console.ForegroundColor = pCC;
    }
  }
}
