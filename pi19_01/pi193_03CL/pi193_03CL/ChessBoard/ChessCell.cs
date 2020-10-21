namespace pi193_03CL.ChessBoard
{
  public class ChessCell
  {

    public Position Pos { get; }
    public EColor Color { get; set; }

    public ChessCell(int iX, int iY, EColor color)
    {
      Pos = new Position(iX, iY);
      Color = color;
    }
  }
}