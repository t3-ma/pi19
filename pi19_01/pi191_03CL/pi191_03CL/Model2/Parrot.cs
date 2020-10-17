using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi191_03CL.Model2
{
  public class Parrot: Animal
  {
    public override string Say()
    {
      return "R";
    }

    public override string Say(string sWord)
    {
      return sWord;
    }
  }
}
