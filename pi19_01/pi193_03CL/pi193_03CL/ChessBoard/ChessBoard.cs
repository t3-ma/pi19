using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi193_03CL.ChessBoard
{
  /// <summary>
  /// Шахматная доска
  /// </summary>
  public class ChessBoard
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="iW"></param>
    /// <param name="iH"></param>
    public ChessBoard(int iW, int iH)
    {

      CellList = new List<ChessCell>();
      h_Fill(iW, iH);
      Width = iW;
      Height = iH;
    }

    /// <summary>
    /// Заполнение поля (создание клеток) заданного размера
    /// </summary>
    /// <param name="iW"></param>
    /// <param name="iH"></param>
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

    #region public properties
    /// <summary>
    /// Свойство: список клеток
    /// </summary>
    public List<ChessCell> CellList { get; }

    /// <summary>
    /// Свойство: ширина поля
    /// </summary>
    public int Width { get; private set; }
    /// <summary>
    /// Свойство: высота поля
    /// </summary>
    public int Height { get; private set; }
    #endregion


    #region public methods
    /// <summary>
    /// Метод, вызывающий реакцию на щелчок мышью
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
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

    /// <summary>
    /// Метод поиска клетки поля по координатам
    /// </summary>
    /// <param name="iX"></param>
    /// <param name="iY"></param>
    /// <returns></returns>
    public ChessCell GetCell(int iX, int iY)
    {
      foreach (ChessCell pC in CellList) {
        if (pC.Pos.X == iX && pC.Pos.Y == iY) {
          return pC;
        }
      }
      return null;
    }

    private const string FileSignature = "[chess]";

    public void Load(string sFileName)
    {
      if (!File.Exists(sFileName)) {
        return;
      }

      CellList.Clear();
      // считать из файла 
      string[] arLine = File.ReadAllLines(sFileName, Encoding.UTF8);
      // ---
      int iLineNum = 0;
      if (arLine[iLineNum++] != FileSignature) {
        return;
      }
      Width = Int32.Parse(arLine[iLineNum++]);
      Height = Int32.Parse(arLine[iLineNum++]);
      for(int ii = iLineNum; ii < arLine.Length; ii++) {
        ChessCell chessCell = new ChessCell(arLine[ii]);
        CellList.Add(chessCell);
      }
    }

    public void Save(string sFileName)
    {
      // сформировать строку для записи в файл
      StringBuilder pSb = new StringBuilder();
      pSb.AppendLine(FileSignature);
      pSb.AppendLine(Width.ToString());
      pSb.AppendLine(Height.ToString());
      foreach (ChessCell pCell in CellList) {
        pSb.AppendLine(pCell.ToString());
      }
      // записать в файл
      string sContent = pSb.ToString();
      File.WriteAllText(sFileName, sContent);
    }


    #endregion

  }
}
