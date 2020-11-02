namespace pi191_03CL.ModelXO
{
  public class Cell
  {

    public override string ToString()
    {
      return $"{PositionX};{PositionY};{Value}";
    }

    public EValue Value { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
  }
}