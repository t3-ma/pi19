using System.Collections.Generic;

namespace pi191_03CL.ModelXO
{
  public class Field
  {
    public Field()
    {
      CellList = new List<Cell>();
      h_FillCell3();
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

    /// <summary>
    /// Найти ячейку в массиве и выставить ей значение
    /// </summary>
    /// <param name="iX"></param>
    /// <param name="iY"></param>
    /// <param name="eValue"></param>
    public void SetValue(int iX, int iY, EValue eValue)
    {
      // TODO: Найти ячейку в массиве и выставить ей значение
    }
  }
}
