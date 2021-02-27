using System.Xml.Serialization;

namespace pi191_03CL.ModelXO
{
  public class Cell
  {

    public override string ToString()
    {
      return $"{PositionX};{PositionY};{Value}";
    }

    [XmlAttribute("value")]
    public EValue Value { get; set; }

    public EValue NewValue
    {
      get => Value;
      set {
        Value = value;
      }
    }

    [XmlAttribute()]
    public int PositionX { get; set; }
    [XmlAttribute()]
    public int PositionY { get; set; }
  }
}