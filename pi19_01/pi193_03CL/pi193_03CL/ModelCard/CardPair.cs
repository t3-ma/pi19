namespace pi193_03CL.ModelCard
{
  public class CCardPair
  {
    public CCardPair(CCard back)
    {
      Back = back;
    }

    public CCard Back { get; }
    public CCard Front { get; set; }
  }
}