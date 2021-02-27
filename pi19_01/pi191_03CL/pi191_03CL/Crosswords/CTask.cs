using System.Collections.Generic;

namespace pi191_03CL.Crosswords
{
  public class CTask
  {
    public CTemplate Template { get; }
    public List<CTaskItem> TaskList { get; }

    public CTask(CTemplate pTemplate)
    {
      TaskList = new List<CTaskItem>();
      Template = pTemplate;
    }

  }
}