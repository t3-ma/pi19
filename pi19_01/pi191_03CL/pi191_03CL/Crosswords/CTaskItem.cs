namespace pi191_03CL.Crosswords
{
  public class CTaskItem
  {
    public CTaskItem(CWord word, string term, string question)
    {
      Word = word;
      Term = term;
      Question = question;
    }

    public CWord Word { get; set; }
    public string Term { get; set; }
    public string Question { get; set; }
  }
}