namespace pi193_03CL.ModelCard
{
  public class CPlayer
  {
    public CPlayer(string name)
    {
      Name = name;
      CardList = new CCardList();
    }

    public string Name { get; set; }
    public CCardList CardList { get; set; }
  }
}