using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace pi191_03CL.ModelXO
{
  /// <summary>
  /// Класс игры
  /// </summary>
  public class Field
  {
    #region constructors
    /// <summary>
    /// конструктор
    /// </summary>
    /// <param name="bAutoFill"></param>
    public Field(bool bAutoFill) : this()
    {
      if (bAutoFill) {
        h_FillCell3();
        h_NextTurn();
      }
    }

    /// <summary>
    /// конструктор
    /// </summary>
    protected Field()
    {
      CellList = new List<Cell>();
      State = EGameState.NewGame;
    }
    #endregion

    #region properties

    [XmlElement("array")]
    public List<Cell> CellList { get; set; }

    /// <summary>
    /// Чей ход текущий
    /// </summary>
    public EValue CurrentTurn { get; set; }

    /// <summary>
    /// Состояние игры:  НоваяИгра, Игра, ИграОкончена
    /// </summary>
    public EGameState State { get; set; }

    public int Width = 3;
    public int Height = 3;
    #endregion

    #region public methods

    public bool NewGame()
    {
      //if (State != EGameState.NewGame) {
      //  return false;
      //}
      h_FillCell3();
      State = EGameState.Game;
      CurrentTurn = EValue.X;
      return true;
    }

    public void Save(string v)
    {
      throw new NotImplementedException();
    }
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
      if (State != EGameState.Game) {
        return false;
      }
      Cell pFoundCell = h_GetCell(iX, iY);
      if (pFoundCell != null) {
        if (pFoundCell.Value == EValue.Empty) {
          pFoundCell.Value = CurrentTurn;

          if (h_IsGameOver()) {
            State = EGameState.GameOver;
            return true;
          }

          h_NextTurn();

          if (CurrentTurn == EValue.O) {
            h_AITurn();
            return true;
          }

          return true;
        }
      }
      return false;
    }

    private void h_AITurn()
    {
      foreach (Cell pCell in CellList) {
        if (pCell.Value == EValue.Empty) {
          pCell.Value = CurrentTurn;

          if (h_IsGameOver()) {
            State = EGameState.GameOver;
            break;
          }
          h_NextTurn();
          break;
        }
      }
    }


    /// <summary>
    /// Получить информацию об игре
    /// </summary>
    /// <returns></returns>
    public string GetInfo()
    {
      return $"Turn: {CurrentTurn}";
    }

    #endregion

    #region private methods
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


    private Cell h_GetCell(int iX, int iY)
    {
      // Cell pFoundCell = CellList.FirstOrDefault(p => p.PositionX == iX && p.PositionY == iY);
      Cell pFoundCell = null;
      foreach (Cell pCell in CellList) {
        if (pCell.PositionX == iX && pCell.PositionY == iY) {
          pFoundCell = pCell;
          break;
        }
      }

      return pFoundCell;
    }


    private bool h_IsGameOver()
    {
      // проверка вертикалей (столбцов)
      for (int ii = 0; ii < Width; ii++) {
        List<Cell> arCells = new List<Cell>();
        for (int jj = 0; jj < Height; jj++) {
          Cell pCell = h_GetCell(ii, jj);
          arCells.Add(pCell);
        }

        if (h_CheckCells(arCells)) {
          return true;
        }
      }

      // проверка горизонталей (строк)
      for (int jj = 0; jj < Height; jj++) {
        List<Cell> arCells = new List<Cell>();
        for (int ii = 0; ii < Width; ii++) {
          Cell pCell = h_GetCell(ii, jj);
          arCells.Add(pCell);
        }
        if (h_CheckCells(arCells)) {
          return true;
        }
      }

      /// проверка лиагонали №1
      List<Cell> arCells1 = new List<Cell>();
      for (int jj = 0; jj < Height; jj++) {
        Cell pCell = h_GetCell(jj, jj);
        arCells1.Add(pCell);
      }
      if (h_CheckCells(arCells1)) {
        return true;
      }

      /// проверка лиагонали №2 
      List<Cell> arCells2 = new List<Cell>();
      for (int jj = 0; jj < Height; jj++) {
        Cell pCell = h_GetCell(Width - jj - 1, jj);
        arCells2.Add(pCell);
      }
      if (h_CheckCells(arCells2)) {
        return true;
      }


      return false;
    }

    private bool h_CheckCells(List<Cell> arCells)
    {
      EValue enV = EValue.Unknown;
      foreach (var pCell in arCells) {
        if (enV == EValue.Unknown) {
          enV = pCell.Value;
          continue;
        }

        if (enV != pCell.Value) {
          return false;
        }
      }
      if (enV == EValue.Empty) {
        return false;
      }
      return true;
    }

    private void h_FillCell3()
    {
      CellList.Clear();
      for (int xx = 0; xx < Width; xx++) {
        for (int yy = 0; yy < Height; yy++) {
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
    #endregion

  }
}
