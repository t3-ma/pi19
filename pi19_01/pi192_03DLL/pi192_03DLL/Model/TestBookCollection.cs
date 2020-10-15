namespace pi192_03DLL.Model
{
  public class TestBookCollection : BookCollection
  {
    public TestBookCollection(string sOwner) : base(sOwner)
    {
      h_TestFill();
    }

    private void h_TestFill()
    {
      BookList.Add(
        new Book()
        {
          Title = "имя 1",
          Author = "й1 ц у"
        });
      BookList.Add(
        new Book()
        {
          Title = "имя 2",
          Author = "й2 ц у"
        });
      BookList.Add(
        new Book()
        {
          Title = "имя 3",
          Author = "й3 ц у"
        });
    }
  }
}