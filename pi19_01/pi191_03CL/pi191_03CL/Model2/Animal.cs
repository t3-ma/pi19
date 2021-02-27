using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using String = System.String;

namespace pi191_03CL.Model2
{
  /// <summary>
  /// Животное
  /// </summary>
  public class Animal
  {
    public virtual string Say()
    {
      return String.Empty;
    }

    public virtual string Say(string sWord)
    {
      return this.Say();
    }

  }
}
