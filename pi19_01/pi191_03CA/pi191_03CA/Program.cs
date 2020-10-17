using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pi191_03CL.Model;
using pi191_03CL.Model2;

namespace pi191_03CA
{
  class Program
  {
    static void Main(string[] args)
    {

      // h_TestPolymorph();
      h_TestMailServer();

      Console.ReadKey();
    }

    private static void h_TestMailServer()
    {
      TestMailServer pMailServer = new TestMailServer("mail.ru");

      int ii = 0;
      foreach (Mailbox pMb in pMailServer.MailboxList)
      {
        Console.WriteLine((++ii).ToString());
        Console.WriteLine(pMb.Address);
        Console.WriteLine($"{pMb.GetUnreadCount()} / {pMb.LetterList.Count}");
      }
    }

    private static void h_TestPolymorph()
    {
      Animal pAnimal;
      pAnimal = new Cow();
      h_MakeNoise(pAnimal);
      pAnimal = new Parrot();
      h_MakeNoise(pAnimal);
    }

    private static void h_MakeNoise(Animal pAnimal)
    {
      Console.WriteLine($"{pAnimal.GetType().Name}: {pAnimal.Say()}");
      Console.WriteLine($"{pAnimal.GetType().Name}: {pAnimal.Say("R!")}");
    }
  }
}
