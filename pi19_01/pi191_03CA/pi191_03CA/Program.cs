using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pi191_03CL.Model;

namespace pi191_03CA
{
  class Program
  {
    static void Main(string[] args)
    {
      TestMailServer pMailServer = new TestMailServer("mail.ru");

      int ii = 0;
      foreach (Mailbox pMb in pMailServer.MailboxList) {
        Console.WriteLine((++ii).ToString());
        Console.WriteLine(pMb.Address);
        Console.WriteLine($"{pMb.GetUnreadCount()} / {pMb.LetterList.Count}");
      }

      Console.ReadKey();
    }
  }
}
