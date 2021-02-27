using System.Collections.Generic;

namespace pi191_03CL.Crosswords
{
  public class CTemplate {
    public List<CWord> WordList { get; }

    public CTemplate()
    {
      WordList = new List<CWord>();
    }
  }
}