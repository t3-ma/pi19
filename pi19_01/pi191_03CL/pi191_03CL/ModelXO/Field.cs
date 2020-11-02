using System;
using System.Collections.Generic;
using System.Linq;

namespace pi191_03CL.ModelXO
{
  public class Field
  {
    public Field()
    {
      CellList = new List<Cell>();
      h_FillCell3();
      h_NextTurn();
    }

    private void h_FillCell3()
    {
      for (int xx = 0; xx < 3; xx++) {
        for (int yy = 0; yy < 3; yy++) {
          Cell pCell = new Cell()
          {
            PositionX = xx,
            PositionY = yy,
            Value = EValue.Empty
          };
          //if (xx == 1 && yy == 1) {
          //  pCell.Value = EValue.X;
          //}
          CellList.Add(pCell);
        }
      }

    }

    public List<Cell> CellList { get; set; }

    public void Save(string v)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Чей ход текущий
    /// </summary>
    public EValue CurrentTurn { get; set; }

    public void Load(string v)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Найти ячейку в массиве и выставить ей значение
    /// </summary>
    /// <param name="iX"></param>
    /// <param name="iY"></param>
    /// <param name="eValue"></param>
    public bool SetValue(int iX, int iY)
    {
      // Cell pFoundCell = CellList.FirstOrDefault(p => p.PositionX == iX && p.PositionY == iY);
      Cell pFoundCell = null;
      foreach (Cell pCell in CellList) {
        if (pCell.PositionX == iX && pCell.PositionY == iY) {
          pFoundCell = pCell;
          break;
        }
      }
      if (pFoundCell != null) {
        if (pFoundCell.Value == EValue.Empty) {
          pFoundCell.Value = CurrentTurn;
          h_NextTurn();
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Получить информацию об игре
    /// </summary>
    /// <returns></returns>
    public string GetInfo()
    {
      return $"Turn: {CurrentTurn}";
    }

    private void h_NextTurn()
    {
      switch (CurrentTurn) {
        case EValue.Empty:
          CurrentTurn = EValue.X;
          break;
        case EValue.X:
          CurrentTurn = EValue.O;
          break;
        case EValue.O:
          CurrentTurn = EValue.X;
          break;
      }
    }
  }
}
