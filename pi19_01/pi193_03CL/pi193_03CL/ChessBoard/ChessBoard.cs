using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi193_03CL.ChessBoard
{
  public class ChessBoard
  {
    public ChessBoard(int iW, int iH)
    {

      CellList = new List<ChessCell>();
      h_Fill(iW, iH);
      Width = iW;
      Height = iH;
    }

    private void h_Fill(int iW, int iH)
    {
      EColor color = EColor.Black;
      for (int iX = 0; iX < iW; iX++) {
        for (int iY = 0; iY < iH; iY++) {
          if (color == EColor.Black) {
            color = EColor.White;
          }
          else {
            color = EColor.Black;
          }

          ChessCell pC = new ChessCell(iX, iY, color);
          CellList.Add(pC);
        }
      }
    }

    public List<ChessCell> CellList { get; }

    public int Width { get; }
    public int Height { get; }

    public void Click(int x, int y)
    {
      ChessCell pCell = GetCell(x, y);
      if (pCell == null) {
        return;
      }
      pCell.Color = pCell.Color == EColor.Black 
        ? EColor.White 
        : EColor.Black;
    }
    public ChessCell GetCell(int iX, int iY)
    {
      foreach (ChessCell pC in CellList) {
        if (pC.Pos.X == iX && pC.Pos.Y == iY) {
          return pC;
        }
      }
      return null;
    }

  }
}
