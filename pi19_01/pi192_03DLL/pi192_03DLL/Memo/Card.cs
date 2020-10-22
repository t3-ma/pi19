using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi192_03DLL.Memo
{
  public class Card
  {
    public Card(int iX, int iY, string symbol)
    {
      Symbol = symbol;
      Location = new Coord(iX, iY);
      IsOpened = false;
    }

    public Coord Location { get; }
    public string Symbol { get; set; }
    public bool IsOpened { get; set; }
  }
}
